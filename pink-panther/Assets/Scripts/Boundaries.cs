using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    
    // https://www.youtube.com/watch?v=ailbszpt_AI&ab_channel=PressStart
    private Vector3 screenBounds;
    private float objectWidth;
    private float objectHeight;
    void Start()
    {
        screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x, (screenBounds.x * -1) - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y, (screenBounds.y * -1) - objectHeight);
        transform.position = viewPos;
    }
}
