using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject[] enemies;
    public GameObject[] healthPanels;

    void Start() {
        currentHealth = maxHealth;
        for (int i = 0; i < healthPanels.Length; i++) {
            healthPanels[i].SetActive(false);
        } 
        healthPanels[0].SetActive(true);
        
    }

    void OnCollisionEnter(Collision collision) {
        foreach(GameObject currentEnemy in enemies) {
            if(currentEnemy.tag == collision.gameObject.tag) {
                TakeDamage(1);
                int index = maxHealth - currentHealth;
                if(index < healthPanels.Length) {
                    healthPanels[index].SetActive(true);
                }
            }
        }
    }

    void Update() {      
        print(currentHealth);  
        if(currentHealth <= 0) {
            SceneManager.LoadScene("Menu");
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
    }
}
