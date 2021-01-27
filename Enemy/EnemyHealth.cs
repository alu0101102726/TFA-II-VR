using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject bullet;
    public bool isMision;
    public LogicaNPC logicNPC;
    public AudioClip audioDeath;
    public AudioClip audioHurt;
    private AudioSource audio;

    void Start() {
        currentHealth = maxHealth;
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision) {
      if(currentHealth <= 0) {
          Destroy(gameObject);
          if (isMision) {
            logicNPC.numObjetivos--;
            logicNPC.textoMision.text = "Mata a 5 Zombunnys \n Restantes: " + logicNPC.numObjetivos;
            if(logicNPC.numObjetivos <= 0) {
              logicNPC.textoMision.text = "Completaste la mision";
              logicNPC.botonMision.SetActive(true);
            }
          }
      }
      if(bullet.tag == collision.gameObject.tag) {
        if(currentHealth == 20) {
          audio.PlayOneShot(audioDeath, 0.5F);
        }
        else {
          audio.PlayOneShot(audioHurt, 0.5F);
        }
        TakeDamage(20);
      }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
    }
}