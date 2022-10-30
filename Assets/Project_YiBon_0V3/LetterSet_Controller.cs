using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSet_Controller : MonoBehaviour
{
    Transform MovingLetter;
    Transform Guide, GuideStart, GuideTarget;
    float speed;
    float speedMin = 0.01f;
    float speedMax; // Letter Guide Speed;

    bool hasReached = false;

    void Start()
    {
        Guide = transform.Find("Guide");
        GuideStart = GameObject.Find("LetterSetContainer").transform;

        GameObject DandelionContainer = GameObject.Find("DandelionContainer");
        int dandelionsCount = DandelionContainer.transform.childCount;
        Transform LatestDandelion = DandelionContainer.transform.GetChild(dandelionsCount - 1);
        //print(LatestDandelion.name);
        GuideTarget = LatestDandelion.Find("Head");
        Guide.position = GuideStart.position;

        speedMax = speedMin * 5;
        speed = Random.Range(speedMin, speedMax);

        MovingLetter = transform.Find("MovingLetter");

        Guide.GetComponent<SpriteRenderer>().enabled = false;        
    }

    // Update is called once per frame
    void Update()
    {
        GuideToStopPoint();
        FollowGuide();
    }

    void GuideToStopPoint()
    {
        Guide.position = Vector3.Lerp(Guide.position, GuideTarget.position, speed);

        float distToStopPoint = Vector3.Distance(Guide.position, GuideTarget.position);
        float randomNum = Random.value;
        if (randomNum < 0.01f)
        {
            float randomRange = distToStopPoint * 0.3f;
            Guide.position += Vector3.one * Random.Range(-randomRange, randomRange);
        }
        if (distToStopPoint < 1f)
        {
            //print("following");
            Guide.position = GuideTarget.position;
        }
    }

    void FollowGuide()
    {
        Vector3 TargetPosition = Guide.position;
        float distToStopPoint = Vector3.Distance(MovingLetter.position, GuideTarget.position);

        float radius = 0.5f;
        if (distToStopPoint > radius * 1.5)
        {
            //print("following");
            MovingLetter.position = Vector3.Lerp(MovingLetter.position, TargetPosition, speed);
        }
        else
        {
            MovingLetter.position = Vector3.Lerp(MovingLetter.position, GuideTarget.position, speed * 0.1f);
            if (!hasReached)
            {
                float angle = Random.Range(0, 360);
                float x = radius * Mathf.Cos(angle) + GuideTarget.position.x;
                float y = radius * Mathf.Sin(angle) + GuideTarget.position.y;
                float z = GuideTarget.position.z;
                speed = 0;
                Vector3 newPos = new Vector3(x, y, z);
                MovingLetter.position = newPos;
                print("stopped");
                hasReached = true;

                GameObject LetterSet = gameObject;
                MovingLetter.SetParent(GuideTarget);
                print(MovingLetter.parent.name);
                Destroy(LetterSet);
            }
            //Destroy(gameObject, 2);
        }
    }
}
