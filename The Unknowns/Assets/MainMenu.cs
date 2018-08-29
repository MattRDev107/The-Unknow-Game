using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    AudioSource ButtonClick;
    bool isClick;

    void Start() {
        ButtonClick = GetComponent<AudioSource>();
    }

    void Update() {
        
    }

    public void PlayGame() {
        
        if(!ButtonClick.isPlaying) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
