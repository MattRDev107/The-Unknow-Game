using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotate : MonoBehaviour {

    [HideInInspector]
    public Quaternion angle;
    public float angleOffset;

    private PlayerController2D playerController2D;
    private float flipset;

    void Start() {
        playerController2D = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController2D>();
    }

    void Update () {
         flipset = (!playerController2D.facingRight) ?180.0f :0.0f;
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        angle = Quaternion.Euler(0.0f, 0.0f, rotZ + flipset);
        angle.z = angle.z + angleOffset;
        transform.rotation = angle;
	}
}
