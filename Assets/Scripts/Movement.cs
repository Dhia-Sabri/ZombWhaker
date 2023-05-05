using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Animator playerAnim;
	public Rigidbody playerRb;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;
	public Transform playerTrans;
	float rotationY = 0f;
	public float sensitivity = 15f;

	void Start()
	{		
		Cursor.visible = false;
	}

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.W))
		{
			playerRb.velocity = transform.forward * w_speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S))
		{
			playerRb.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
	}
	void Update()
	{
        if (Input.GetKeyDown(KeyCode.Space))
			{
			playerAnim.Play("Jump");
		    }
       
        if (Input.GetMouseButton(0))
        {
			playerAnim.Play("SwordSlash");
        }
		if (Input.GetKeyDown(KeyCode.W))
		{
			playerAnim.SetTrigger("Walk");
			playerAnim.ResetTrigger("Idle");
			walking = true;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			playerAnim.ResetTrigger("Walk");
			playerAnim.SetTrigger("Idle");
			playerRb.velocity = Vector3.zero;
			w_speed = olw_speed;
			walking = false;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			playerAnim.SetTrigger("Backwards");
			playerAnim.ResetTrigger("Idle");
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			playerAnim.ResetTrigger("Backwards");
			playerAnim.SetTrigger("Idle");
		}
		rotationY += Input.GetAxisRaw("Mouse X") * sensitivity;
		transform.localEulerAngles = new Vector3(0, rotationY, 0);
		if (walking == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{				
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("Forwards");
				playerAnim.ResetTrigger("Walk");
			}
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				w_speed = olw_speed;
				playerAnim.ResetTrigger("Forwards");
				playerAnim.SetTrigger("Walk");
			}
		}
	}
}

