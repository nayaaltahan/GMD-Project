using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    [SerializeField] public float fallMultiplier = 2.5f;

    [SerializeField] public float lowJumpMultiplier = 2f;
    
    [SerializeField] public float jumpVelocity = 15f;

    private Rigidbody2D rb;
    
    [SerializeField] public Animator mainCharacterAnimator;

    private GroundCheck groundCheck; 

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = transform.Find("GroundCheck").GetComponent<GroundCheck>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            mainCharacterAnimator.SetTrigger("Jump");
            rb.velocity = new Vector3(0, jumpVelocity, 0);
        }
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        }

        if (groundCheck.fall)
        {
            mainCharacterAnimator.SetTrigger("Fall");
            groundCheck.fall = false;
        }
    }
    
    
    bool IsGrounded()
    {
        return groundCheck.isGrounded;
    }
}
