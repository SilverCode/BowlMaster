using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Vector3 initialVelocity;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
	    rigidBody = GetComponent<Rigidbody>();
	    rigidBody.velocity = initialVelocity;
	    audioSource = GetComponent<AudioSource>();
	    audioSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
