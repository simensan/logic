using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    private bool escapingCatcher;
    private Color ballColor = Color.blue;
    private Vector2 speed = new Vector2(0,0);

    public void InvertDirection() {
        speed.Scale(new Vector2(-1,-1));
    }
	
	void Update () {
	    if (speed != Vector2.zero) {
            transform.Translate(speed.x * Time.deltaTime, speed.y * Time.deltaTime, 0);    
	    } 
	}

    public void Stop() {
        this.speed = Vector2.zero;
    }

    public void SetColor(Color color) {
        this.ballColor = color;
        Renderer matRenderer = GetComponent<Renderer>();
        matRenderer.material.color = color;
    }

    public void Fire(Vector2 direction) {
        speed = direction;
        escapingCatcher = true;
    }

    public Color GetColor() {
        return ballColor;
    }

    void OnTriggerExit2D(Collider2D coll) {
        if (escapingCatcher) {
            escapingCatcher = false;
        }
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag != "ballcatcher") {
            Debug.Log("collided with other than catcher: " + coll.gameObject.tag);
            return;
        }

        BallCatcher ballCatcher = coll.gameObject.GetComponent<BallCatcher>();

        if (ballCatcher.IsFree()  && !escapingCatcher) {
            Debug.Log("ball catcher was null");
            transform.position = coll.gameObject.transform.position;

            ballCatcher.SetBall(GetComponent<Ball>());
            Stop();
        } else if(!escapingCatcher) {
            Debug.Log("inverting");
            InvertDirection();
        }
    }
}


//TODO DELETE BALLS?