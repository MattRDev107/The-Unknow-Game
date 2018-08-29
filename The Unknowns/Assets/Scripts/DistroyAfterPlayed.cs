using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistroyAfterPlayed : MonoBehaviour {

    public ParticleSystem Particle;

    void Start() {
        Particle = GetComponent<ParticleSystem>();
    }

    void Update() {
        if (Particle.isStopped) {
            Destroy(gameObject);
        }
    }
}
