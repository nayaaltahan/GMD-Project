﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    
    public bool isGrounded;

    public bool fall;

    private void OnTriggerStay2D(Collider2D other)
    {
        isGrounded = other != null && (((1 << other.gameObject.layer) & platformLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isGrounded = false;
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            fall = true;
        }
    }
}
