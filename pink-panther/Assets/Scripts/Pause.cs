using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour 
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
    }
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)) 
        {
            pausePanel.SetActive(!pausePanel.activeSelf);
            if (pausePanel.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }

        } 
    }
    
}
