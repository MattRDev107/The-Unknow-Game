using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float power = 0.7f;
    public float duration = 1.0f;
    public float Damping = 1.0f;
    public bool shouldShake = false;

    private Vector3 startPosition;
    private float initialDuration;
    private Transform camera;

    void Start() {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = duration;
    }

    void Update() {
        if (shouldShake) {
            startPosition = camera.localPosition;
            if(duration > 0) {
                camera.localPosition = startPosition + new Vector3(Random.insideUnitSphere.x,Random.insideUnitSphere.y) * power;
                duration -= Time.deltaTime * Damping;
            }
            else {
                shouldShake = false;
                duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }
}
