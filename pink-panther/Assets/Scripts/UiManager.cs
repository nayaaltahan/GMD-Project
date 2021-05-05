using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UiManager : MonoBehaviour
{
    [SerializeField] public GameObject MenuGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            MenuGameObject.SetActive(!MenuGameObject.activeSelf);
        }
    }

// might help later for music volume 
    public void Save(string file)
    {
        PlayerPrefs.SetString("file", file);
    }

    public void GetConfig(string key)
    {
        PlayerPrefs.GetString(key);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }

    public void ChangeTextColor()
    {
        
    }
}
