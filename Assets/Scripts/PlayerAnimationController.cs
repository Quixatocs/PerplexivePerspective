using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour {


    public PlayerController playerController;

    private Vector3 moveDirection;
    private Animator animator;



	void Update () {
        moveDirection = playerController.GetMovementDirection();



    }
}
