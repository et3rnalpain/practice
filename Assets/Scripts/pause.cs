using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{

    private Points point;
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject panel;
    private bool isPaused = false; 
    // Start is called before the first frame update
    private void Start()
    {
        point = scoreText.GetComponent<Points>();
        panel.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && point.isGameStarted == true) 
        { 
            if (isPaused) 
            { 
                Resume(); 
            } 
            else 
            { 
                Pause(); 
            } 
        }
    }


    private void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        AudioListener.volume=0;
    }

    public void Resume() 
    { 
        panel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false; 
        AudioListener.volume=1;
    } 

}
