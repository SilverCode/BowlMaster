using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public Text pinsText;
    public float distanceToRaise = 40;
    public GameObject pinSet;

    private bool shouldCountPins = false;
    private int lastStandingCount = -1;
    private float lastChangeTime;
    private Ball ball;

	// Use this for initialization
	void Start ()
	{
	    ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (shouldCountPins)
	    {
	        pinsText.text = CountStanding().ToString();
	        CheckStanding();
	    }
	}

    public void RaisePins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pin.Raise(distanceToRaise);
            }
        }
    }

    public void LowerPins()
    {
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
            {
                pin.Lower(distanceToRaise);
            }
        }
    }

    public void RenewPins()
    {
        GameObject currentPins = GameObject.Find("Pins");
        String pinsName = currentPins.name;
        if (currentPins)
            Destroy(currentPins);

        GameObject newPins = Instantiate(pinSet, new Vector3(0, 5, 1829), Quaternion.identity);
        newPins.transform.Rotate(0, 180, 0);
        newPins.name = pinsName;
    }

    private void CheckStanding()
    {
        // Update lastStandingCount
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3;
        if (Time.time - lastChangeTime > settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        lastStandingCount = -1;
        shouldCountPins = false;
        pinsText.color = Color.green;
        ball.Reset();
    }

    private int CountStanding()
    {
        int uprightPins = 0;
        foreach (Pin pin in FindObjectsOfType<Pin>())
        {
            if (pin.isStanding())
                uprightPins++;
        }

        return uprightPins;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>() != null)
        {
            shouldCountPins = true;
            pinsText.color = new Color(1f, 0f, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Pin pin = other.GetComponentInParent<Pin>();
        if (pin)
        {
            Destroy(pin.gameObject);
        }
    }
}
