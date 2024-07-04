using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject pl;
    private Vector3 offset;
    private Animator animator;
    void Start()
    {
        offset = new Vector3(0,2,-4);
        player = pl.transform.GetChild(0).transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("StartGame", true);
            pl.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
    void FixedUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + player.position.z);
        transform.position = newPosition;
    }

    private void StopAnim()
    {
        GetComponent<Animator>().enabled = false;
    }
}