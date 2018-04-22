using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitEventTriggers : MonoBehaviour {

    private const string DEATH_TAG = "DeathTag";
    private const string CHECKPOINT_TAG = "CheckpointTag";
    private const string LEVEL_COMPLETE_TAG = "LevelCompleteTag";
    private const string SAT2_TAG = "Sat2Tag";
    private const string SAT3_TAG = "Sat3Tag";
    private const string SAT4_TAG = "Sat4Tag";
    private const string SAT5_TAG = "Sat5Tag";
    private const string SAT6_TAG = "Sat6Tag";
    private const string SAT7_TAG = "Sat7Tag";
    private const string SAT8_TAG = "Sat8Tag";
    private const string SAT9_TAG = "Sat9Tag";

    WaitForSeconds checkpointCooldownWait = new WaitForSeconds(5f);

    bool isAvailableToTrigger = true;



    void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case DEATH_TAG:
                EventManager.invokeSubscribersTo_Death();
                break;
            case CHECKPOINT_TAG:
                if (isAvailableToTrigger)
                {
                    isAvailableToTrigger = false;
                    StartCoroutine(CooldownCheckpoint());
                    EventManager.invokeSubscribersTo_UpdateCheckpoint(other.transform.position);
                    other.gameObject.GetComponent<CheckpointController>().TurnCheckpointOn();
                }
                break;
            case LEVEL_COMPLETE_TAG:
                EventManager.invokeSubscribersTo_LevelComplete(other.gameObject.GetComponent<SendToNextLevel>().GetNextLevelTransform());
                break;
            case SAT2_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(1);
                break;
            case SAT3_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(2);
                break;
            case SAT4_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(3);
                break;
            case SAT5_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(4);
                break;
            case SAT6_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(5);
                break;
            case SAT7_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(6);
                break;
            case SAT8_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(7);
                break;
            case SAT9_TAG:
                EventManager.invokeSubscribersTo_TransitionMusic(8);
                break;
            default:
                break;
        }
   
    }


    
    IEnumerator CooldownCheckpoint()
    {
        yield return checkpointCooldownWait;
        isAvailableToTrigger = true;
    }
    


}
