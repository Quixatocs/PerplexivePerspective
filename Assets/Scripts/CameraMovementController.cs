using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour {

    public Transform target;
    public float yOffset;
    public float cameraSmoothTime = 0.15f;

    private Vector3 velocity = Vector3.zero;
 
    void LateUpdate () {

        Vector3 destination = new Vector3(target.position.x, target.position.y + yOffset, target.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, cameraSmoothTime);
    }
}
