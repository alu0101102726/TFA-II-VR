using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerManager : MonoBehaviour {
    private AudioSource audioClip;
    public GameObject speakerClip;
    void Start() {  
        audioClip = speakerClip.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            audioClip.Play();
            gameObject.SetActive(false);
        }
    }
}