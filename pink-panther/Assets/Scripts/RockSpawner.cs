using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform rockPrefab;
    [SerializeField] private float timeLeft = 2000.0f;
    private Vector3 spawnPosition;
    
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        Transform rock = Instantiate<Transform>(rockPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
       // Physics2D.IgnoreCollision(rock.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
    
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft < 0)
        {
            //Transform rock = Instantiate<Transform>(rockPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
        }
    }
    
}
