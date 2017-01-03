using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 3f;

    private Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public bool isStanding()
    {
        if (transform.eulerAngles.x < standingThreshold && transform.eulerAngles.z < standingThreshold)
            return true;

        return false;
    }

    public void Raise(float distToRaise)
    {
        rigidBody.useGravity = false;
        transform.Translate(0, distToRaise, 0);
    }

    public void Lower(float distToLower)
    {
        transform.Translate(0, -distToLower, 0);
        rigidBody.useGravity = true;
    }

}
