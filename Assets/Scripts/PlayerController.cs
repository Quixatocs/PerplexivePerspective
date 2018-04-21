using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    private const string START_CHECKPOINT_TAG = "StartCheckpointTag";

    public float speed = 6.0F;
    public float jumpForce = 100.0F;

    public Animator playerAnimator;

    private Vector3 moveDirection = Vector3.zero;
    private bool isJumping = false;
    private WaitForSeconds jumpCooldown = new WaitForSeconds(0.5f);

    private Vector3 checkpoint;


    void OnEnable()
    {
        EventManager.death += ResetToCheckpoint;
        EventManager.updateCheckpoint += UpdateCheckpoint;
    }

    void OnDisable()
    {
        EventManager.death -= ResetToCheckpoint;
        EventManager.updateCheckpoint -= UpdateCheckpoint;
    }

    void Start()
    {
        checkpoint = GameObject.FindGameObjectWithTag(START_CHECKPOINT_TAG).transform.position;
    }

    void Update()
    {

        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        if (isJumping == false && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            playerAnimator.SetBool("Jumping", isJumping);
            GetComponent<Rigidbody>().AddForce(Vector2.up * jumpForce);
            EventManager.invokeSubscribersTo_Jump();
            StartCoroutine(jumpCooldownTimer());
        }
        else
        {
            float xAbs = Mathf.Abs(moveDirection.x);
            float zAbs = Mathf.Abs(moveDirection.z);
            if (xAbs > 0 || zAbs > 0)
            {
                if (xAbs > zAbs)
                {
                    playerAnimator.SetFloat("LandMovement", xAbs);
                }
                else
                {
                    playerAnimator.SetFloat("LandMovement", zAbs);
                }
            }
        }


        

        transform.position += moveDirection * Time.deltaTime;
    }

    private IEnumerator jumpCooldownTimer()
    {
        yield return jumpCooldown;
        isJumping = false;
        playerAnimator.SetBool("Jumping", isJumping);
    }

    void ResetToCheckpoint()
    {
        transform.position = checkpoint;
    }

    void UpdateCheckpoint(Vector3 newCheckpointPosition)
    {
        checkpoint = newCheckpointPosition;
    }

    public Vector3 GetMovementDirection()
    {
        return moveDirection;
    }


}
