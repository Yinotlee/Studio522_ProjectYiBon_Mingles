using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterSetContainer_Controller : MonoBehaviour
{
    public GameObject LetterSet;
    DandelionTrumble Trumble;

    private void Start()
    {
        //Trumble = GameObject.Find("DandelionContainer").
    }

    public void CloneLetterSet(string UserText)
    {

        foreach(char c in UserText)
        {
            //print(c);
            GameObject Clone = Instantiate(LetterSet);
            Clone.transform.SetParent(transform);
            Clone.transform.position = transform.position;

            GameObject LetterObject = Clone.transform.GetChild(1).GetChild(0).gameObject;            
            LetterObject.GetComponent<TextMeshPro>().text = c.ToString();
            LetterObject.GetComponent<TextMeshPro>().fontSize = Random.Range(2.5f, 6.5f);

            byte color = (byte)Random.Range(0, 150);
            byte alpha = (byte)Random.Range(150, 255);
            LetterObject.GetComponent<TextMeshPro>().color = new Color32(color, color, color, alpha);
        }
    }
}
