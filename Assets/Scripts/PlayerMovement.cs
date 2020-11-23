using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public float walking = 0f;
	public Animator anim;

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (horizontalMove != 0 )
        {
			anim.SetFloat("Speed", horizontalMove);
			anim.SetBool("Andando", true);
		} else
        {
			anim.SetBool("Andando", false);
		}


		if (Input.GetButtonDown("Jump"))
		{
			jump = true;

			if (controller.checkPotion())
			{
				controller.m_JumpForce = 400f;
			} else
            {
				controller.m_JumpForce = 200f;
			}
		}

		if (Input.GetButtonDown("Vertical"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Vertical"))
		{
			crouch = false;
		}

	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;

	}
}