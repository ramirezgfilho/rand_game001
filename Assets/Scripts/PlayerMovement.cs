﻿	using System.Collections;
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
			//anim.SetBool("Pulo", true);

		}

		if (Input.GetButtonDown("Vertical"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Vertical"))
		{
			crouch = false;
		}

		if (Input.GetButtonDown("Fire2"))
        {


            if (controller.checkPotion())
            {
				controller.m_JumpForce = 400f;
				Debug.Log("Poder de pulo aumentada!");
				controller.jumpPotions--;
            } else
            {
				Debug.Log("Poção de pulo indisponível.");
            }
        }

		if(Input.GetButtonDown("Fire1"))
        {
			anim.SetTrigger("Attack");
		}



	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
		controller.checkPotion();

	}
}