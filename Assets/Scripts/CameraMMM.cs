using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Points point;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject mainmenuPanel;


    [SerializeField] private Transform player;
    [SerializeField] private GameObject pl;
    private Vector3 offset;
    private Animator animator;
    void Start()
    {
        gamePanel.SetActive(false);
        point = scoreText.GetComponent<Points>();
        offset = new Vector3(0,2,-4);
        player = pl.transform.GetChild(0).transform;
        animator = GetComponent<Animator>();
        point.isGameStarted = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        animator.SetBool("StartGame", true);
        pl.transform.GetChild(0).gameObject.SetActive(true);
        point.isGameStarted = true;
        gamePanel.SetActive(true);
        mainmenuPanel.SetActive(false);
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