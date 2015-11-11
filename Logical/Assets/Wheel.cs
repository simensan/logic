using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {
    public BallCatcher[] catchers;
    private Color invalidColor = new Color(-1, -1, -1);
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	    bool complete = true;
        Color color = invalidColor;
        foreach (BallCatcher catcher in catchers) {
            Ball ball = catcher.GetBall();
            if (ball == null) {
                complete = false;
                break;
            }

            if (color.Equals(invalidColor)) {
                color = ball.GetColor();
            } else {
                if (!color.Equals(ball.GetColor())) {
                    complete = false;
                    break;
                }
            }
        }

	    if (complete) {
            Debug.Log("Destroying wheel");
	        DestroyImmediate(gameObject);
	    }
    }   
}
