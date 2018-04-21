using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEventTriggers : MonoBehaviour {

    private const string DEATH_TAG = "DeathTag";
    private const string CHECKPOINT_TAG = "CheckpointTag";

    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case DEATH_TAG:
                EventManager.invokeSubscribersTo_Death();
                break;
            case CHECKPOINT_TAG:
                EventManager.invokeSubscribersTo_UpdateCheckpoint(other.transform.position);
                other.gameObject.GetComponent<CheckpointController>().TurnCheckpointOn();
                break;
            default:
                break;

        }


    }
}
