using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    private bool isPaused = false; 
    // Start is called before the first frame update
    private void Start()
    {
        panel.SetActive(false); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
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
    }

    public void Resume() 
    { 
        panel.SetActive(false); 
        Time.timeScale = 1f; 
        isPaused = false; 
    } 

}
