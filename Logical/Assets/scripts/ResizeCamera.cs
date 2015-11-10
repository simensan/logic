using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ResizeCamera : MonoBehaviour {

    public float defaultAspect = 16 / 9f;

    void Start() {
        GetComponent<Camera>().orthographicSize = defaultAspect / GetComponent<Camera>().aspect * GetComponent<Camera>().orthographicSize;
    }
}
