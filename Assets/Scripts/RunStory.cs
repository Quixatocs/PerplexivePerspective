using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStory : MonoBehaviour {

    public GameObject[] storyText;

    public GameObject stage1Text;

    public GameObject levelDetailsText;

    public GameObject controlsText;

    public PlayerController playerController;

    public float waitTime = 0.8f;
    WaitForSeconds textWait;
    public float startWaitTime = 0.8f;
    WaitForSeconds startWait;



    void Awake()
    {
        textWait = new WaitForSeconds(waitTime);
        startWait = new WaitForSeconds(startWaitTime);

        foreach (GameObject item in storyText)
        {
            item.SetActive(false);
        }

        stage1Text.SetActive(false);
        levelDetailsText.SetActive(false);
        controlsText.SetActive(false);
        playerController.enabled = false;

        StartCoroutine(RunStoryActions());
    }


    private IEnumerator RunStoryActions()
    {
        yield return startWait;

        foreach (GameObject item in storyText)
        {
            item.SetActive(true);
            yield return textWait;
            item.SetActive(false);
        }

        stage1Text.SetActive(true);
        yield return textWait;

        levelDetailsText.SetActive(true);
        yield return textWait;

        controlsText.SetActive(true);
        yield return textWait;

        playerController.enabled = true;

    }
}
