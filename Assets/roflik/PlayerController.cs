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
    [SerializeField] private const int maxSpeed = 30;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    //[SerializeField] private GameObject losePanel;

    private int lineToMove = 1;
    public float lineDistance = 4; 

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        StartCoroutine(SpeedIncrease());
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

             if (Input.GetKeyDown(KeyCode.S))
            {
                Roll();
            }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0)
            targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2)
            targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);

        if (Physics.Raycast(transform.position,Vector3.down,0.5f))
        {
            anim.SetBool("isGrounded", true);
        }
    }

    private void Jump()
    {
        dir.y = jumpForce;
        anim.SetBool("Jump",true);
        anim.SetBool("isGrounded", false);
    }

    private void Dead()
    {
        dead = true;
        anim.SetBool("Jump", false);
        anim.SetBool("Dead", true);
    }

    private void Roll()
    {
        anim.SetBool("Roll", true);
        anim.SetBool("isGrounded", false);
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        if(!dead) controller.Move(dir * Time.fixedDeltaTime);
    }

    private void StopJump() 
    {
        anim.SetBool("Jump", false);
    }

    private void StopRoll()
    {
        anim.SetBool("Roll", false);
        anim.SetBool("isGrounded",true);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "obstacle")
        {
            //losePanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }
    
    //нарастание скорости
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(5);
        if (speed < maxSpeed)
        {
            speed += 3;
            StartCoroutine(SpeedIncrease());
        }
    }

    //подбор монетки
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("+1 coin");
            Destroy(other.gameObject);
        }
    }
}