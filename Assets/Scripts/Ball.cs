using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 initialVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 initialPosition;

	// Use this for initialization
	void Start () {
	    rigidBody = GetComponent<Rigidbody>();
	    audioSource = GetComponent<AudioSource>();
	    rigidBody.useGravity = false;
	    initialPosition = transform.position;
	}

    public void Launch(Vector3 velocity)
    {
        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;
        inPlay = true;
    }

    public void Reset()
    {
        inPlay = false;
        rigidBody.useGravity = false;
        rigidBody.velocity = new Vector3(0, 0, 0);
        rigidBody.angularVelocity = new Vector3(0, 0, 0);
        transform.position = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (inPlay)
        {
            GameObject floor = GameObject.Find("Floor");
            if (other.gameObject == floor)
            {
                audioSource.Play();
            }
        }
    }
}
