using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public SpriteRenderer target;
    
    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    //https://www.youtube.com/watch?v=MFQhpwc6cKE&ab_channel=Brackeys
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp (transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
