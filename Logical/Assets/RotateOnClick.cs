using UnityEngine;
using System.Collections;

public class RotateOnClick : MonoBehaviour {

    void OnMouseDown() {
        transform.Rotate(Vector3.forward, 45f);
    }
}
