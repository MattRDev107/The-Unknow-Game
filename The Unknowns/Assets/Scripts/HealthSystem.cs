using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem {

    private float health;
    private float maxHealth;

    public HealthSystem(float maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public float GetHealth() {
        return health;
    }

    public void Damge(float damgeAmount) {
        health -= damgeAmount;
        if (health < 0.0f) health = 0.0f;
    }
    
    public void Heal(float HealAmount) {
        health += HealAmount;
        if (health > maxHealth) health = maxHealth;
    }
}
