using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;
    private Ball ball;
    private float MAX_X, MIN_X;

	// Use this for initialization
	void Start ()
	{
	    ball = GetComponent<Ball>();

	    GameObject floor = GameObject.Find("Floor");
	    MAX_X = (floor.transform.position.x + (floor.transform.localScale.x/2)) - ball.transform.localScale.x;
	    MIN_X = (floor.transform.position.x - (floor.transform.localScale.x/2)) + ball.transform.localScale.x;
	}

    public void DragStart()
    {
        dragStart = Input.mousePosition;
        startTime = Time.time;
    }

    public void DragEnd()
    {
        dragEnd = Input.mousePosition;
        endTime = Time.time;

        float dragDuration = endTime - startTime;

        float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
        float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

        Vector3 launchVelocity = new Vector3(launchSpeedX, 0, launchSpeedZ);

        ball.Launch(launchVelocity);
    }

    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            Vector3 newBallPosition = ball.transform.position;
            newBallPosition.x += amount;
            if (newBallPosition.x < MAX_X && newBallPosition.x > MIN_X)
                ball.transform.position = newBallPosition;
        }
    }
}
