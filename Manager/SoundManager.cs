using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {
    private static SoundManager instance = null;
    public static SoundManager Instance {get {return instance; } }
    private static AudioSource audio;
    public AudioClip mainMusic;
    public AudioClip clickAudio;

    void Awake() {
        if (instance != null && instance != this) {
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    void Start() {
        audio = GetComponent<AudioSource>();
        if (audio.isPlaying) {
            audio.PlayOneShot(mainMusic, 0.7F);
        }
    }

    public void PlaySonidoClick() {
        audio.PlayOneShot(clickAudio, 1.0F);
    }
}
