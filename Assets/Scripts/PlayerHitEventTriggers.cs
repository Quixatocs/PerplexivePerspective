using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEventTriggers : MonoBehaviour {

    private const string DEATH_TAG = "DeathTag";
    private const string CHECKPOINT_TAG = "CheckpointTag";
    private const string LEVEL_COMPLETE_TAG = "LevelCompleteTag";
    private const string MOVING_PLATFORM_TAG = "MovingPlatformTag";

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
            case LEVEL_COMPLETE_TAG:
                EventManager.invokeSubscribersTo_LevelComplete(other.gameObject.GetComponent<SendToNextLevel>().GetNextLevelTransform());
                break;
            case MOVING_PLATFORM_TAG:
                //Debug.Log("GotHere");
                //GetComponent<Rigidbody>().isKinematic = true;
                //transform.parent = other.transform;
                //EventManager.invokeSubscribersTo_LevelComplete(other.gameObject.GetComponent<SendToNextLevel>().GetNextLevelTransform());
                break;
            default:
                break;

        }


    }
}
