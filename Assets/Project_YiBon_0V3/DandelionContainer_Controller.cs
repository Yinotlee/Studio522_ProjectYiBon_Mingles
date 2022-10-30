using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionContainer_Controller : MonoBehaviour
{
    public List<GameObject> Dandelions;
    float bottomY = -3;
    void Start()
    {
        print(Dandelions.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloneDandelion(string UserText)
    {      
        GameObject Dandelion = Instantiate(Dandelions[Random.Range(0, Dandelions.Count - 1)]);
        print(Dandelion.name);
        Dandelion.transform.SetParent(transform);
        
        float randomH = 6.5f;
        Vector3 NewPos = new Vector3(transform.position.x + Random.Range(-randomH, randomH), bottomY, 0);
        print(NewPos);
        Dandelion.transform.position = NewPos;

        //Dandelion.GetComponent<SpriteRenderer>().enabled = false;
        Dandelion.transform.Find("Head").GetComponent<SpriteRenderer>().enabled = false;
        Dandelion.transform.Find("Origin").GetComponent<SpriteRenderer>().enabled = false;

        Dandelion.transform.Find("Head").GetComponent<DandelionTrumble>().LettersCount = UserText.Length;
    }
}
