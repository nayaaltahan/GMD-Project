using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = System.Numerics.Vector2;

public class WalkingScript : MonoBehaviour
{
    [SerializeField] public Animator mainCharacterAnimator;
    [SerializeField] public float speed;

    private void Start()
    {
        speed = (float) (transform.localScale.x * speed);
    }

    void Update()
    {
        Run();
    }

    private void Run()
    {
        var transformLocalScale = transform.localScale;
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            if (horizontal > 0)
            {
                // I decided to go for flipping the scale instead of the flipping the sprite, to make sure that the collider is also flipping with the image of the character
                if(transformLocalScale.x < 0)
                    transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
                transform.position += Vector3.right * (speed * Time.deltaTime);
            }

            if (horizontal < 0)
            {
                if(transformLocalScale.x > 0)
                    transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
                transform.position += Vector3.left * (speed * Time.deltaTime);
            }
            mainCharacterAnimator.SetBool("Move", true);
        }
        else
        {
            mainCharacterAnimator.SetBool("Move", false);
        }
    }
}
