using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    private Pin[] pins;
    public Text pinsText;

	// Use this for initialization
	void Start () {
        pins = GameObject.FindObjectsOfType<Pin>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    int standingPins = CountStanding();
	    pinsText.text = standingPins.ToString();
	}

    int CountStanding()
    {
        int uprightPins = 0;
        foreach (Pin pin in pins)
        {
            if (pin.isStanding())
                uprightPins++;
        }

        return uprightPins;
    }
}
