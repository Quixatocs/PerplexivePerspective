using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollow : MonoBehaviour {

    public Transform target;
    public float fixedYPosition;

	void Update () {
        Vector3 newPosition = new Vector3(target.position.x, fixedYPosition, target.position.z);
        transform.position = newPosition;
    }
}
