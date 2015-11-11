using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool allowDown;
    public bool allowLeft;
    public bool allowRight;
    public bool allowUp;
    public BallCatcher[] catchers; //Up, Left, Down, Right
    private readonly Color invalidColor = new Color(-1, -1, -1);
    public LinkedList<BallCatcher> rotatedCatchers = new LinkedList<BallCatcher>();

    private int upIndex = 0;
    // Use this for initialization
    private void Start()
    {
        foreach (var ballCatcher in catchers)
        {
            rotatedCatchers.AddLast(ballCatcher);
        }

        UpdateDirections();
    }

    // Update is called once per frame
    private void Update()
    {
        var complete = true;
        var color = invalidColor;
        foreach (var catcher in catchers)
        {
            var ball = catcher.GetBall();
            if (ball == null)
            {
                complete = false;
                break;
            }

            if (color.Equals(invalidColor))
            {
                color = ball.GetColor();
            }
            else
            {
                if (!color.Equals(ball.GetColor()))
                {
                    complete = false;
                    break;
                }
            }
        }

        if (complete)
        {
            Debug.Log("Destroying wheel");
            DestroyImmediate(gameObject);
        }
    }

    private void OnMouseDown()
    {
        var last = rotatedCatchers.Last;
        rotatedCatchers.RemoveLast();
        rotatedCatchers.AddFirst(last); //shift catchers around

        UpdateDirections();

        transform.Rotate(Vector3.forward, 90f);
    }

    private void UpdateDirections()
    {
        var upCatcher = rotatedCatchers.ElementAt(0);
        var rightCatcher = rotatedCatchers.ElementAt(3);
        var downCatcher = rotatedCatchers.ElementAt(2);
        var leftCatcher = rotatedCatchers.ElementAt(1);

        upCatcher.SetEnabled(allowUp);
        leftCatcher.SetEnabled(allowLeft);
        downCatcher.SetEnabled(allowDown);
        rightCatcher.SetEnabled(allowRight);

        upCatcher.SetDirection(new Vector2(0, 1));
        leftCatcher.SetDirection(new Vector2(-1, 0));
        downCatcher.SetDirection(new Vector2(0, -1));
        rightCatcher.SetDirection(new Vector2(1, 0));
    }
}