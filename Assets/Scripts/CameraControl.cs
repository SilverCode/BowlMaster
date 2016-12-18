using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
	    Vector3 newPos = ball.transform.position + offset;
	    if (newPos.z < 1829)
	    {
	        transform.position = newPos;
	    }
	}
}
