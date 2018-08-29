using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour {

    public Transform target;
    [Range(0,1)]
    public float snapSpeed;

    private Vector3 offset;
    private Vector3 velocity;

    void Start() {
        offset = new Vector3(0, 0, -10);
    }

    void FixedUpdate() {
        Vector3 moveToTarget = Vector3.SmoothDamp(transform.position, target.position, ref velocity, snapSpeed);
        transform.position = moveToTarget + offset;
    }
}
