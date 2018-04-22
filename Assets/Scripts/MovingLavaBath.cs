using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLavaBath : MonoBehaviour {

    public float startYPosition;
    public float endYPosition;
    public float speed = 0.01f;

    private float pointAlongLine = 0f;

    private Vector3 startPos;
    private Vector3 endPos;


    private bool isTravellingUpwards = false;

    void Start()
    {
        startPos = new Vector3(transform.localPosition.x, startYPosition, transform.localPosition.z);
        endPos = new Vector3(transform.localPosition.x, endYPosition, transform.localPosition.z);
        FlipDirection();

    }

    void Update()
    {

        if (isTravellingUpwards)
        {
            pointAlongLine += speed;
        }
        else
        {
            pointAlongLine -= speed;
        }

        if (pointAlongLine > 1f)
        {
            pointAlongLine = 1f;
            FlipDirection();
        }

        if (pointAlongLine < 0f)
        {
            pointAlongLine = 0f;
            FlipDirection();
        }

        transform.localPosition = Vector3.Lerp(startPos, endPos, pointAlongLine);
        
    }


    void FlipDirection()
    {
        isTravellingUpwards = !isTravellingUpwards;

    }
}
