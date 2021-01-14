using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public Rigidbody currentAmmo;
    public float speed = 1000f;
    private AudioSource audio;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    void Start() {        
        audio = GetComponent<AudioSource>();
    }
   
    void disparar() {
        Rigidbody ammoClone = (Rigidbody) Instantiate(currentAmmo, transform.position, currentAmmo.rotation);
        ammoClone.velocity = transform.forward * speed;
    }

    void Update() {
        if(Input.GetButtonDown("Fire1")) {
            audio.PlayOneShot(shootSound, 0.5F);
            disparar();
        }
    }
}
