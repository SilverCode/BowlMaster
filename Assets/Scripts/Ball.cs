using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 initialVelocity;

    public bool inPlay = false;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
	    rigidBody = GetComponent<Rigidbody>();
	    audioSource = GetComponent<AudioSource>();
	    rigidBody.useGravity = false;
	}

    public void Launch(Vector3 velocity)
    {
	    //audioSource.Play();
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        inPlay = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        GameObject floor = GameObject.Find("Floor");
        if (other.gameObject == floor)
        {
            audioSource.Play();
        }
    }
}
