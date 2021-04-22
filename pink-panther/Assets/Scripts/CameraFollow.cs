using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] 
    public GameObject player;

    [SerializeField] public float timeOffset;

    [SerializeField] public Vector2 posOffset;

    private Vector3 velocity;


    [SerializeField] public float leftLimit;
    [SerializeField] public float rightLimit;
    [SerializeField] public float bottomLimit;
    [SerializeField] public float topLimit;

    void Update()
    {
        // Cameras current position
        Vector3 startPos = transform.position;
        
        // players current position
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;
        
        
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);
        
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit,rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }
}
