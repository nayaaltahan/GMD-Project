using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject MenuGameObject;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        Time.timeScale = 1;
    }
    
    public void Continue()
    {
        MenuGameObject.SetActive(false);
        Time.timeScale = 1;
    }
    
}
