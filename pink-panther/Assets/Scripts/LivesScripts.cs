using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LivesScripts : MonoBehaviour, Observer
{
    [SerializeField] private List<GameObject> hearts;
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
            Debug.Log("Game Over");
        }
        
    }
}
