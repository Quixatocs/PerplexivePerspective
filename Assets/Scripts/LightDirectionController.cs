using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDirectionController : MonoBehaviour {

    int[] rotationPositions = { 270, 0, 90, 180 };
    int rotationIndex = 0;

    [Range(0,3)]
    public int startingRotationIndex;

    new Light light; 

    float[] timeLightIntensities;

    [Range(0f, 1f)]
    public float rotationSpeed = 0.5f;

    void Start()
    {
        rotationIndex = startingRotationIndex;
        light = GetComponent<Light>();
    }

	void Update () {
		
        if (Input.GetKeyUp(KeyCode.K))
        {
            rotationIndex++;
            if (rotationIndex > rotationPositions.Length - 1)
                rotationIndex = 0;
            if (rotationIndex < 0)
                rotationIndex = rotationPositions.Length - 1;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.eulerAngles.x, rotationPositions[rotationIndex], transform.rotation.eulerAngles.z), rotationSpeed);

    }
}
