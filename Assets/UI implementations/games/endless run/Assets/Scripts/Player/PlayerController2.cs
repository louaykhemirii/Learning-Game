using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1; //0:left 1:middle 2:right
    public float laneDistance = 4; //the distance between two lane 
    public float jumpforce;
    public float Gravity = -20;
    public float maxSpeed;
  
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public Animator animator;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        
    }
	// Update is called once per frame
	void Update()
    {
        if (!PlayerManager2.isGameStarted)
        {
			return;
		}

        //Increase Speed
        if(forwardSpeed < maxSpeed)
        {
			forwardSpeed += 0.1f * Time.deltaTime;
		}

        animator.SetBool("isGameStarted", true);
        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.15f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);
        if (controller.isGrounded)
        {
            direction.y = -1;
            if (SwipeManager1.swipeUp)
			StartCoroutine(Jump());
		}
        else
            direction.y += Gravity * Time.deltaTime;

        if(SwipeManager1.swipeDown)
        {
            StartCoroutine(Slide());
        }

        //Gather the inputs on which lane we should be 
        if (SwipeManager1.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

        if (SwipeManager1.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }
        Running();
		Move();


	}
    private void Move()
    {
		Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
		if (desiredLane == 0)
		{
			targetPosition += Vector3.left * laneDistance;
		}
		else if (desiredLane == 2)
		{
			targetPosition += Vector3.right * laneDistance;
		}
		if (transform.position != targetPosition)
		{
			Vector3 diff = targetPosition - transform.position;
			Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
			if (moveDir.sqrMagnitude < diff.magnitude)
				controller.Move(moveDir);
			else
				controller.Move(diff);
		}
		controller.Move(direction * Time.deltaTime);
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag == "obstacle")
        {
            PlayerManager2.gameOver = true;
            FindObjectOfType<AudioManager2>().PlaySound("GameOver");
        }
    }
    private IEnumerator Slide()
    {
     
        animator.SetBool("isSliding", true);
        controller.center = new Vector3(0, -0.5f, 0);
        controller.height = 1;

        yield return new WaitForSeconds(0.8f);

        controller.center = new Vector3(0, 0, 0);
        controller.height = 2;

        animator.SetBool("isSliding", false);
       
    }

	private IEnumerator Jump()
	{

		animator.SetBool("isJumping", true);
		direction.y = jumpforce;
		yield return new WaitForSeconds(0.8f);

		animator.SetBool("isJumping", false);
	}

    private IEnumerator Running()
    {
        Debug.Log("testing");
		animator.SetBool("isRunning", true);
		yield return new WaitForSeconds(0.8f);
		animator.SetBool("isRunning", false);
	}
}
