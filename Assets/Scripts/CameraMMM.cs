using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Points point;
    private Settings setting;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject mainmenuPanel;
    [SerializeField] private GameObject shopPanel;

    [SerializeField] private GameObject settingsPanel;


    public Transform player;
    public GameObject pl;
    private Vector3 offset;
    private Animator animator;
    void Start()
    {
        gamePanel.SetActive(false);
        point = scoreText.GetComponent<Points>();
        setting = settingsPanel.GetComponent<Settings>();
        offset = new Vector3(0,2,-4);
        player = pl.transform.GetChild(0).transform;
        animator = GetComponent<Animator>();
        point.isGameStarted = false;
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
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
    public void StartSettings()
    {
        settingsPanel.SetActive(true);
        mainmenuPanel.SetActive(false);
    }
    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainmenuPanel.SetActive(true);
    }
    public void StartShop()
    {
        mainmenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    public void CloseShop()
    {
        mainmenuPanel.SetActive(true);
        shopPanel.SetActive(false);
    }
    public void CloseGame()
    {
        Application.Quit();
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

    public void goToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}