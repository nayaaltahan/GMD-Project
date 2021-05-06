using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollideScript : MonoBehaviour
{
    private SpriteRenderer playerSpriteRenderer;

    private Subject subject;

    private List<Observer> observers;
    void Start()
    {
        playerSpriteRenderer = GameObject.FindWithTag("Player").GetComponent<SpriteRenderer>();
        subject = new Subject();
        observers = new List<Observer>();
        observers.Add(FindObjectOfType<LivesScripts>());
        foreach (var observer in observers)
        {
            subject.AddObserver(observer);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ChangeColors());
            subject.Notify();
        }
    }
    
    private IEnumerator ChangeColors()
    {
        for (int i = 0; i < 5; i++)
        {
            playerSpriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            playerSpriteRenderer.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
