using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour {
    public Rigidbody currentAmmo;
    public float speed = 100f;
    private AudioSource audio;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    private int ammo;

    void Start() {        
        audio = GetComponent<AudioSource>();
        //UpdateAmmo();
        ammo = 7;
    }

    void Reload() {
        audio.PlayOneShot(reloadSound, 0.5F);
        ammo = 7;
        //UpdateAmmo();
    }
   
    void Disparar() {
        Vector3 ammoPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Rigidbody ammoClone = (Rigidbody) Instantiate(currentAmmo, ammoPosition, currentAmmo.rotation);
        ammoClone.velocity = transform.forward * (-speed);
        ammo--;
       // UpdateAmmo();
    }

    void Update() {
        if((Input.GetButtonDown("Fire3") || Input.GetKeyDown(KeyCode.F)) && ammo > 0) {
            audio.PlayOneShot(shootSound, 0.5F);
            Disparar();
        }
        if(Input.GetButtonDown("Fire1") || Input.GetKeyDown(KeyCode.R)) {
            Reload();
        }
    }

    // void UpdateAmmo(){
    //     ammoText.text = ""+ammo;
    // }
}
