using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour {
    public bool isPickable = true;
    public bool isSpecial = false;
    private AudioSource audio;
    public GameObject activableTrigger;

    void Start() {
        if(GetComponent<AudioSource>() != null) {
            audio = GetComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "PlayerInteractionZone") {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "PlayerInteractionZone") {
            other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = null;
        }

    }

    public void PlayTape() {
        print("Play audio");
        audio.Play();
    }
}
