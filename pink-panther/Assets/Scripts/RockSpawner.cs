using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    [SerializeField] private Collider2D player;
    [SerializeField] private Transform rockPrefab;
    private Vector3 spawnPosition;
    [SerializeField] private Animator dinoAnimator;
    [SerializeField] private AnimationClip dropAnimation;
    private List<Transform> rocks;
    
    void Start()
    {
        spawnPosition = gameObject.transform.position;
        StartCoroutine(ThrowRocks());
        rocks = new List<Transform>();
    }
    
    void Update()
    {
        
    }
    
    private IEnumerator ThrowRocks()
    {
        var spawnDuration = 10f;
        var next = 0;
        while (true)
        {
            dinoAnimator.SetTrigger("Drop");
            yield return new WaitForSeconds(dropAnimation.length);
            if (rocks.Count <= 10)
            {
                Transform rock = Instantiate<Transform>(rockPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
                Physics2D.IgnoreCollision(rock.GetComponent<Collider2D>(), player);
                rocks.Add(rock);
            }
            else
            {
                rocks[next].SetPositionAndRotation(spawnPosition, Quaternion.identity);
                rocks[next].gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                next = (next < 10) ? next + 1 :  0;
                Debug.Log(next);
            }
            
            if (spawnDuration > 6)
            {
                spawnDuration -= 0.5f;
            }
            yield return new WaitForSeconds(spawnDuration);
        }
    }
    
}
