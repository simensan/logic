using UnityEngine;
using System.Collections.Generic;

public class BallSpawner : MonoBehaviour {
    public Ball ballPrefab;

    public int timeBetweenSpawnsInSeconds = 2;
    public Vector2 direction = new Vector2();
    public int speed = 10;
    private readonly List<Color> colors = new List<Color>();

    private float counter = Mathf.Infinity;

    // Use this for initialization
	void Start () {
	    direction.Scale(new Vector2(speed, speed));
        colors.Add(Color.blue);
        colors.Add(Color.yellow);
        colors.Add(Color.red);
	}
	
	// Update is called once per frame
	void Update () {
	   counter += Time.deltaTime;
	    if (counter >= timeBetweenSpawnsInSeconds) {
	        Spawn();
	        counter = 0;
	    }
	}

    private void Spawn() {
        Ball ballObject = GameObject.Instantiate(ballPrefab);
        ballObject.transform.position = transform.position;
        ballObject.SetColor(colors[Random.Range(0, colors.Count)]);
        ballObject.Fire(direction);
    }
}
