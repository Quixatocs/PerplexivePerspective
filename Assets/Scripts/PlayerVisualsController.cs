using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualsController : MonoBehaviour {

    public PlayerController playerController;


    private Vector3 moveDirection;

    private const float UP_ROTATION = 0f;
    private const float RIGHT_ROTATION = 90f;
    private const float DOWN_ROTATION = 180f;
    private const float LEFT_ROTATION = -90f;

    Quaternion newRotation;

    void Update () {
        moveDirection = playerController.GetMovementDirection();

        float xAbs = Mathf.Abs(moveDirection.x);
        float zAbs = Mathf.Abs(moveDirection.z);

        if (xAbs > zAbs)
        {
            if (moveDirection.x > 0)
            {
                newRotation = Quaternion.Euler(0f, RIGHT_ROTATION, 0f);
            }
            else if (moveDirection.x < 0)
            {
                newRotation = Quaternion.Euler(0f, LEFT_ROTATION, 0f);
            }
        }
        else
        {
            if (moveDirection.z > 0)
            {
                newRotation = Quaternion.Euler(0f, UP_ROTATION, 0f);
            }
            else if (moveDirection.z < 0)
            {
                newRotation = Quaternion.Euler(0f, DOWN_ROTATION, 0f);
            }
        }

        transform.rotation = newRotation;


    }
}
