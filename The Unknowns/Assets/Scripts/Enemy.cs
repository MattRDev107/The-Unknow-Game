using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float damge;
    public float health = 0.0f;
    private HealthSystem healthSystem;

    void Start() {
        healthSystem = new HealthSystem(health);
        Debug.Log("Health: " + healthSystem.GetHealth());
    }
    
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Projectile")) {
            healthSystem.Damge(damge);
            Debug.Log("hit");
            Debug.Log("Health: " + healthSystem.GetHealth());
        }
    }
}
