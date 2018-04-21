using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour {

    public Material checkpointOnMaterial;
    public Material checkpointOffMaterial;

    void OnEnable()
    {
        EventManager.updateCheckpoint += UpdateCheckpoint;
    }

    void OnDisable()
    {
        EventManager.updateCheckpoint -= UpdateCheckpoint;
    }


    public void TurnCheckpointOn()
    {
        GetComponent<MeshRenderer>().material = checkpointOnMaterial;
    }

    private void UpdateCheckpoint(Vector3 notNeeded)
    {
        TurnCheckpointOff();
    }

    private void TurnCheckpointOff()
    {
        GetComponent<MeshRenderer>().material = checkpointOffMaterial;
    }
}
