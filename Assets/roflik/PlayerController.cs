using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 dir;

    private bool dead = false;
    [SerializeField] private int speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;

    private int lineToMove = 1;
    public float lineDistance = 4; 

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (lineToMove < 2)
                lineToMove++;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (lineToMove > 0)
                lineToMove--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controller.isGrounded)
                Jump();
        }

    if (Input.GetKeyDown(KeyCode.W))
            {
                Dead();
            }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        transform.position = targetPosition;

        //if(transform.position.y < 0.1) anim.SetBool("Jump",false);
    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetBool("Jump",true);
    }

    private void Dead()
    {
        dead = true;
        anim.SetBool("Jump", false);
        anim.SetBool("Dead", true);
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        if(!dead) controller.Move(dir * Time.fixedDeltaTime);
    }
}