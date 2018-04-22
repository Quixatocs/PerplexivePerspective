using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMover : MonoBehaviour {

    public Transform parentPosition;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 0.01f;

    private float pointAlongPath = 0f;

    private Vector3 destination;

    private Rigidbody rigidBody;


    private bool isTravellingTowardsEnd = false;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        FlipDestination();
    }

	void Update () {

        if (isTravellingTowardsEnd)
        {
            pointAlongPath += speed;
        }
        else
        {
            pointAlongPath -= speed;
        }

        if (pointAlongPath > 1f)
        {
            pointAlongPath = 1f;
            FlipDestination();
        }

        if (pointAlongPath < 0f)
        {
            pointAlongPath = 0f;
            FlipDestination();
        }

        rigidBody.MovePosition(Vector3.Lerp(startPosition + parentPosition.position, endPosition + parentPosition.position, pointAlongPath));
    }


    void FlipDestination()
    {
        isTravellingTowardsEnd = !isTravellingTowardsEnd;

    }

}
