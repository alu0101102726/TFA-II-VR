using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject[] enemies;

    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter(Collision collision) {
        if(currentHealth == 0) {
            SceneManager.LoadScene("Menu");
        }
        foreach(GameObject currentEnemy in enemies) {
            if(currentEnemy.tag == collision.gameObject.tag) {
                TakeDamage(20);
            }
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
