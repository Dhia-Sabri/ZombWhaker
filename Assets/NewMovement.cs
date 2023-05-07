using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public Animator anim;

    public float speed = 3f;

    public bool iswalking, isSprinting;
    


    public float TurnSmoothTime = 0.1f;
    float turnsmoothvelocity;

    private void Awake()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
        float horizental = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizental, 0f, vertical).normalized;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 6f;
            isSprinting = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 3f;
            isSprinting = false;
        }
        
        if (direction.magnitude >= 0.1f)
        {
            iswalking = true;
            float TargetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float Angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref turnsmoothvelocity, TurnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, Angle, 0f);

            Vector3 movedirection = Quaternion.Euler(0f, TargetAngle, 0f) * Vector3.forward;
            controller.Move(movedirection.normalized * speed * Time.deltaTime);
        }
        else
        {
            iswalking = false;
        }

        animHandler();

    }

    void animHandler()
    {
        if (Input.GetMouseButton(0))
        {
            anim.Play("SwordSlash");
        }
        if (iswalking && !isSprinting)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isWalking", true);
        }
        else if (iswalking && isSprinting)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
    }
}
