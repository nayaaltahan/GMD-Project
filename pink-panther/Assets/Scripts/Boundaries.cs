using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{

    // https://www.youtube.com/watch?v=ailbszpt_AI&ab_channel=PressStart
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    [SerializeField] private Transform background;

    // Use this for initialization
    void Start()
    {
        screenBounds = new Vector2(background.GetComponent<SpriteRenderer>().bounds.extents.x,background.GetComponent<SpriteRenderer>().bounds.extents.y);
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}
