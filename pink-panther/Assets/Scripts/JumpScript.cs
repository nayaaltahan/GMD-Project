using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public float fallMultiplier = 2.5f;

    public float lowJumpMultiplier = 2f;

    private Rigidbody2D rb;
    
    [SerializeField] public Animator mainCharacterAnimator;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            mainCharacterAnimator.SetTrigger("Jump");
            rb.velocity = new Vector3(0, 10, 0);
        }
        if (rb.velocity.y < 0)
        {
            mainCharacterAnimator.ResetTrigger("Jump");

            if (rb.velocity.y > -0.5)
            {
                if (!mainCharacterAnimator.GetBool("Fall"))
                {
                    mainCharacterAnimator.SetBool("Fall", true);
                }
            }
        }
        if (rb.velocity.y == 0)
        {
            mainCharacterAnimator.SetBool("Fall", false);
        }
        
        // if (rb.velocity.y < 0)
        // {
        //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime);
        // }
        // else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        // {
        //     rb.velocity += Vector2.up * (Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime);
        // }
        
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log(col);

        if (col.gameObject.tag.Equals("Platform"))
        {    
            Vector3 hit = col.contacts[0].normal;
            Debug.Log(hit);
            float angle = Vector3.Angle(hit, Vector3.up);
 
            if (Mathf.Approximately(angle, 0))
            {
                //Down
                Debug.Log("Down");
            }
            if(Mathf.Approximately(angle, 180))
            {
                //Up
                Debug.Log("Up");
            }
            if(Mathf.Approximately(angle, 90)){
                // Sides
                Vector3 cross = Vector3.Cross(Vector3.forward, hit);
                if (cross.y > 0)
                { // left side of the player
                    Debug.Log("Left");
                }
                else
                { // right side of the player
                    Debug.Log("Right");
                }
            }
        }
    }
}
