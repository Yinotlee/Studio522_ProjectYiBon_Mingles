using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionTrumble : MonoBehaviour
{
    float timePassed;
    Vector3 OriginalPos;
    Vector3 OriginalScale;
    public int LettersCount;
    float randomScale = 0.3f;

    GameObject HitTarget;

    bool isAudioPlaying = false;


    void Start()
    {
        OriginalPos = transform.position;
        OriginalScale = transform.localScale;

        HitTarget = GameObject.Find("HandPos");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartTrumble();
        }

        float dist = Vector3.Distance(transform.position, HitTarget.transform.position);
        
        //print(dist);
        if(dist < 1.5f)
        {
            StartTrumble();
            //PlayAudio();
        }
        Trumble();
    }

    public void StartTrumble()
    {
        if (transform.childCount == LettersCount)
        {
            timePassed = 0;
            randomScale = Random.Range(0f, 0.08f);
            PlayAudio();
        }        
    }
    void PlayAudio()
    {
        if (!isAudioPlaying)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            print("play audio:" + audio.clip.name);
            isAudioPlaying = true;
        }
    }

    void Trumble()
    {
        timePassed += Time.deltaTime;
        //PlayAudio();
        if (timePassed < 1f)
        {
            //transform.position = OriginalPos + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            float randomS = Random.Range(-randomScale, randomScale);
            transform.localScale = OriginalScale + new Vector3(randomS, randomS, randomS);
        }
        else
        {
            //transform.position = OriginalPos;
            transform.localScale = OriginalScale;
            isAudioPlaying = false;
        }
    }
}
