using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	    print(name + " " + isStanding());
	}

    public bool isStanding()
    {
        if (transform.eulerAngles.x < standingThreshold && transform.eulerAngles.z < standingThreshold)
            return true;

        return false;
    }
}
