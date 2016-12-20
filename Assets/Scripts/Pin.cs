using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public float standingThreshold = 3f;

    public bool isStanding()
    {
        if (transform.eulerAngles.x < standingThreshold && transform.eulerAngles.z < standingThreshold)
            return true;

        return false;
    }
}
