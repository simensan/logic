using UnityEngine;
using System.Collections;

public class BallCatcher : MonoBehaviour
{
    public int speed;
    public Vector2 direction;
    public Ball ball;

    void Awake() {
        direction.Scale(new Vector2(speed, speed));
    }

    void OnMouseDown() {
        Debug.Log("md1");
        if (ball != null) {
            Debug.Log("md2");
            ball.gameObject.GetComponent<CircleCollider2D>().enabled = true;
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
}
