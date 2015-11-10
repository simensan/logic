using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ResizeCamera : MonoBehaviour {

    public float defaultAspect = 4 / 3f;

    void Start() {
        GetComponent<Camera>().orthographicSize = defaultAspect / GetComponent<Camera>().aspect * GetComponent<Camera>().orthographicSize;
    }
}
