using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject[] healthPanels;

    void Start() {
        currentHealth = maxHealth;
        for (int i = 0; i < healthPanels.Length; i++) {
            healthPanels[i].SetActive(false);
        } 
        healthPanels[0].SetActive(true);
        
    }

    void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            TakeDamage(1);
            int index = maxHealth - currentHealth;
            if(index < healthPanels.Length) {
                healthPanels[index].SetActive(true);
            }
        }
    }

    void Update() {
        if(currentHealth <= 0) {
            SceneManager.LoadScene("Menu");
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
    }
}
