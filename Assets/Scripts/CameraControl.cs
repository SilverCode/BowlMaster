﻿using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Ball ball;
    private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
	    offset = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (transform.position.z <= 1700 || !ball.inPlay)
	    {
	        transform.position = ball.transform.position + offset;
	    }
	}
}
