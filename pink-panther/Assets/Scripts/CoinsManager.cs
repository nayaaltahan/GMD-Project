using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    private List<GameObject> coins;
    [SerializeField] private Transform winningPanel;
    [SerializeField] private Transform winningParent;
    void Start()
    {
        coins = new List<GameObject>(GameObject.FindGameObjectsWithTag("Coin"));
    }

    // Update is called once per frame
    void Update()
    {
        if (coins.Count == 0)
        {
            Transform gameOver = Instantiate<Transform>(winningPanel, winningParent);
            Time.timeScale = 0;
        }
    }

    public void removeSelf(GameObject coin)
    {
        coins.Remove(coin);
    }
    
}
