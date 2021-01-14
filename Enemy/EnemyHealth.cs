using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject bullet;

    void Start() {
        currentHealth = maxHealth;
    }

    void OnCollisionEnter(Collision collision) {
      if(currentHealth == 0) {
          Destroy(gameObject);
      }
      if(bullet.tag == collision.gameObject.tag) {
        TakeDamage(20);
      }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;
    }
}