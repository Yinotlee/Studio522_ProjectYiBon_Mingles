using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;

public class Button_Controller : MonoBehaviour
{
    public InputField UserInput;
    string UserText;
    //LetterSetContainer_Controller LetterSetContainerScript;

    private void Start()
    {
        UserInput.ActivateInputField();
        UserInput.Select();

        string text = UserInput.GetComponent<InputField>().text;
        //print(text);

        //LetterSetContainerScript = GameObject.Find("LetterSetContainer").GetComponent<LetterSetContainer_Controller>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            OnClick_LetCloneObjects();
        }
    }

    public void OnClick_LetCloneObjects()
    {
        UserText = UserInput.text;
        if (UserText.Length > 0)
        {
            LetClone_Dandelion();
            LetClone_LetterSet();
        }
        UserInput.text = "";
        UserInput.ActivateInputField();
        UserInput.Select();
    }
    public void LetClone_LetterSet()
    {
        //UserText = UserInput.text;
        //UserInput.text = "";
        GameObject.Find("LetterSetContainer").GetComponent<LetterSetContainer_Controller>().CloneLetterSet(UserText);

    }
    public void LetClone_Dandelion()
    {
        GameObject.Find("DandelionContainer").GetComponent<DandelionContainer_Controller>().CloneDandelion(UserText);
    }
}
