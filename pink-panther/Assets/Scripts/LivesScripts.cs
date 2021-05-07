using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LivesScripts : MonoBehaviour, Observer
{
    [SerializeField] private List<GameObject> hearts;
    [SerializeField] private Transform gameOverPanel;
    [SerializeField] private Transform gameOverParent;

    private int last;

    private void Start()
    {
        last = hearts.Count - 1;
    }

    public void OnNotify()
    {
        Destroy(hearts[last]);
        hearts.RemoveAt(last--);
        if (hearts.Count == 0)
        {
            Transform gameOver = Instantiate<Transform>(gameOverPanel, gameOverParent);
        }
        
    }
}
