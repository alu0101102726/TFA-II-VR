using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGameManager : MonoBehaviour {
    private AudioSource audio;
    public AudioClip mainMusic;
    void Start() {        
        SoundManager.Instance.gameObject.GetComponent<AudioSource>().Pause();
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(mainMusic, 0.7F);
    }
}
