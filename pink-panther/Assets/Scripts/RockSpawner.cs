using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform rockPrefab;
    private Vector3 spawnPosition;
    [SerializeField] private Animator dinoAnimator;
    [SerializeField] private AnimationClip dropAnimation;
    
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        StartCoroutine(StartCountdown());
        // Physics2D.IgnoreCollision(rock.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }
    
    void Update()
    {
        
    }
    
    private IEnumerator StartCountdown()
    {
        var spawnDuration = 10f;
        while (true)
        {
            dinoAnimator.SetTrigger("Drop");
            yield return new WaitForSeconds(dropAnimation.length);
            Debug.Log("Animation is over");
            Transform rock = Instantiate<Transform>(rockPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
            if (spawnDuration > 4)
            {
                spawnDuration -= 0.5f;
            }
            yield return new WaitForSeconds(spawnDuration);
        }
    }
    
}
