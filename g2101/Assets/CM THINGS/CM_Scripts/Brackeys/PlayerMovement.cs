using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public bool SlamTest = false;
	public GameObject Sprite;
	public bool doubleJump;
	public bool doubleJumpReq;

	public bool canDash = true;
	public bool isDashing;
	public float dashingPower = 24f; 
	public float dashingTime = 0.2f;
	public float dashingCooldown = 1f;

	[SerializeField] private TrailRenderer tr;
	[SerializeField] private Rigidbody2D rb;

	void Update () {
		if (isDashing)
		{
			return;
		}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			doubleJumpReq = true;
			animator.SetBool("Jump", true);
		}

		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		} else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
		{
			StartCoroutine(Dash());
		}

		if (doubleJumpReq)
		{
		 if (Input.GetKeyDown(KeyCode.J))
			{
				doubleJump = true;
				doubleJumpReq = false;
			}
		}
	}

	void FixedUpdate ()
	{
		if (isDashing)
		{
			return;
		}

		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump, doubleJump, doubleJumpReq);
		jump = false;
		animator.SetBool("Jump", false);
		doubleJump = false;
	}

	private IEnumerator SlamTimer()
	{
		yield return new WaitForSeconds(1f);
		SlamTest = false;
		animator.SetBool("Slam", SlamTest);
		Sprite.SetActive(true);
	}
	private IEnumerator Dash()
	{
		canDash = false;
		isDashing = true;
		float originalGravity = rb.gravityScale;
		rb.gravityScale = 0f; 
		rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
		tr.emitting = false;
		rb.gravityScale = originalGravity;
		isDashing = false;
		yield return new WaitForSeconds(dashingCooldown);
		canDash = true;
	}
}
