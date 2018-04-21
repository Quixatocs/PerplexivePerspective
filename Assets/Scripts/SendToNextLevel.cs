using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendToNextLevel : MonoBehaviour {

    public Transform nextLevelTarget;

    public Vector3 GetNextLevelTransform()
    {
        return nextLevelTarget.position;
    }

}
