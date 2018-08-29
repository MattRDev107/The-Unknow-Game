using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasingSound : MonoBehaviour {

    public AudioClip dropSound;
    public int limitOfAudioSource;

    void Update() {
        
    }

    void OnParticleCollision(GameObject other) {
        AudioSource.PlayClipAtPoint(dropSound, transform.position, 50.0f);
    }
}