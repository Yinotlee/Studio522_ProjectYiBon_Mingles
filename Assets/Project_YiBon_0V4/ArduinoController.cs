using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;
using TMPro;

public class ArduinoController : MonoBehaviour
{
    public InputField InputField;
    string InputText;
    public DandelionContainer_Controller DandelionContainerScript;

    SerialPort Arduino;
    string portName = "COM5";
    //string portName = "/dev/cu.usbmodem14201";
    public string SerialIn = null;

    public List<AudioClip> AudioClips;

    void Start()
    {
        string[] ports = SerialPort.GetPortNames();

        foreach (string port in ports)
        {
            print(port);
        }
        Arduino = new SerialPort(portName.ToString(), 9600);
        Arduino.Open();
        Arduino.ReadTimeout = 1000; //milliseconds
    }

    void Update()
    {
        if (Arduino.IsOpen)
        {
            try
            {
                SerialIn = Arduino.ReadLine();
                //print("raw:" + SerialIn);
                if (SerialIn != null)
                {
                    SerialIn = SerialIn.Trim();
                    //print("trimmed:" + SerialIn);
                    if (SerialIn == "1")
                    {
                        print("got 1");
                        //Clone();
                        LetCloneObjects();

                    }
                }
            }
            catch (Exception e)
            {
                print(e);
            }
            Arduino.Write("*");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlayAudio();
        }
    }

    public void LetCloneObjects()
    {      
        InputText = InputField.text;
        print(InputText);
        if (InputText.Length > 0)
        {
            PlayAudio();
            LetClone_Dandelion();
            LetClone_LetterSet();
        }
        else
        {
            GameObject.Find("DandelionContainer").GetComponent<DandelionContainer_Controller>().TrumbleAll();
        }
        InputField.text = "";
        InputField.ActivateInputField();
        InputField.Select();
    }
    void LetClone_LetterSet()
    {
        GameObject.Find("LetterSetContainer").GetComponent<LetterSetContainer_Controller>().CloneLetterSet(InputText);

    }
    void LetClone_Dandelion()
    {
        GameObject.Find("DandelionContainer").GetComponent<DandelionContainer_Controller>().CloneDandelion(InputText);
    }

    void PlayAudio()
    {
        AudioSource audio = GetComponent<AudioSource>();
        int index = UnityEngine.Random.Range(0, AudioClips.Count);
        audio.clip = AudioClips[index];
        print(index + "," + AudioClips[index].name);
        audio.Play();
    }

    void OnApplicationQuit()
    {
        Arduino.Close();
    }
}
