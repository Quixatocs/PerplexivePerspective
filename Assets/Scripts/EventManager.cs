using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance = null;

    public delegate void Jump();
    public static event Jump jump;



    void Awake()
    {
        singleton();
    }

    void singleton()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }




    public static void invokeSubscribersTo_Jump()
    {
        if (jump != null)
            jump();
    }
}
