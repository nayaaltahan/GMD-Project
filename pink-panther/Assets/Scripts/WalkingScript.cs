using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Vector2 = System.Numerics.Vector2;

public class WalkingScript : MonoBehaviour
{
    [SerializeField] public Animator mainCharacterAnimator;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField] public float speed;

    private void Start()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        speed = (float) (transform.localScale.x * speed);
    }

    void Update()
    {
        Run();
    }

    private void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            if (horizontal > 0)
            {
                mySpriteRenderer.flipX = false;
                transform.position += Vector3.right * (speed * Time.deltaTime);
            }

            if (horizontal < 0)
            {
                mySpriteRenderer.flipX = true;
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
