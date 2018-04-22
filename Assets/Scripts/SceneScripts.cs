using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScripts : MonoBehaviour {


	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Attempted To Quit");
            Application.Quit();
        }	
	}
}
