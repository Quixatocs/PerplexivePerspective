using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovementController : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpForce = 100.0F;
    private Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;
    private WaitForSeconds jumpCooldown = new WaitForSeconds(0.5f);


    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (isJumping == false && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce);
            EventManager.invokeSubscribersTo_Jump();
            StartCoroutine(jumpCooldownTimer());
        }

        if (moveDirection.x > 0f)
        {
            transform.localScale = new Vector3(-1f, transform.localScale.y, 1f);
        }
        else if (moveDirection.x < 0f)
        {
            transform.localScale = new Vector3(1f, transform.localScale.y, 1f);
        }

        transform.position += moveDirection * Time.deltaTime;
    }

    private IEnumerator jumpCooldownTimer()
    {
        yield return jumpCooldown;
        isJumping = false;
    }

	
}
