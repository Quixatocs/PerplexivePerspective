using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance = null;

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

    public delegate void Jump();
    public static event Jump jump;

    public delegate void Death();
    public static event Death death;

    public delegate void UpdateCheckpoint(Vector3 newCheckpoint);
    public static event UpdateCheckpoint updateCheckpoint;
    

    public static void invokeSubscribersTo_Jump()
    {
        if (jump != null)
            jump();
    }

    public static void invokeSubscribersTo_Death()
    {
        if (death != null)
            death();
    }

    public static void invokeSubscribersTo_UpdateCheckpoint(Vector3 newCheckpoint)
    {
        if (updateCheckpoint != null)
            updateCheckpoint(newCheckpoint);
    }


}
