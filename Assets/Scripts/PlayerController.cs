using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Points point;
    private Vector3 dir;

    private bool dead = false;
    [SerializeField] private int speed;
    [SerializeField] private const int maxSpeed = 30;
    [SerializeField] private float jumpForce;

    [SerializeField] private GameObject scoreText;
    [SerializeField] private float gravity;

    [SerializeField] private TMP_Text coinsText;
    //[SerializeField] private GameObject losePanel;
    private int coins;

    private int lineToMove = 1;
    public float lineDistance = 4; 

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        point = scoreText.GetComponent<Points>();
        point.pointMultiplier = 1;
        anim = GetComponent<Animator>();
        StartCoroutine(SpeedIncrease());
    }

    private void Update()
    {
        if(!dead){
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

            if (Input.GetKeyDown(KeyCode.S))
            {
                Roll();
            }
        }
        //СМЭРТ
        Vector3 fr = gameObject.transform.position;
        fr.y += 0.5f;
        Debug.DrawRay(fr, new Vector3(0,0,1.5f),Color.red);
        Ray ray = new Ray(fr,new Vector3(0,0,1.5f));
        if(Physics.Raycast(ray,out RaycastHit hit,1.5f))
        {
            if(hit.collider && !dead)
            {
                Dead();
            }
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

        if (Physics.Raycast(transform.position,Vector3.down,0.5f))
        {
            anim.SetBool("isGrounded", true);
        }
    }

    private void StopJump() 
    {
        anim.SetBool("Jump", false);
        anim.SetBool("isGrounded",true);
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
        yield return new WaitForSeconds(10);
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
            coins++;
            coinsText.text = coins.ToString();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "boost")
        {
            StartCoroutine(X2Bonus());
            Destroy(other.gameObject);
        }
    }

    private IEnumerator X2Bonus()
    {
        point.pointMultiplier = 2;

        yield return new WaitForSeconds(5);

        point.pointMultiplier = 1;
    }


}