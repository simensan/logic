using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.scripts;


public class BallCatcher : MonoBehaviour
{
    public int speed;
    public Ball ball;

    private Vector2 direction;

    void Awake() {
        
    }

    void OnMouseDown() {
        if (ball != null && enabled) {
            ball.gameObject.GetComponent<CircleCollider2D>().enabled = true;
            Debug.Log(direction.ToString());
            ball.Fire(direction);
            ball.transform.SetParent(null);
            ball = null;
        }
    }

    public void SetBall(Ball ball) {
        this.ball = ball;
        ball.gameObject.GetComponent<CircleCollider2D>().enabled = false;
        ball.transform.SetParent(transform);
    }

    public bool IsFree() {
        return ball == null;
    }

    public Ball GetBall() {
        return ball;
    }

    public void SetDirection(Vector2 vector2)
    {
        direction = vector2;
        direction.Scale(new Vector2(speed, speed));
    }

    public void SetEnabled(bool enabled)
    {
        this.enabled = enabled;
    }
}
