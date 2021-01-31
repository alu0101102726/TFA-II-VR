/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se controla la salud del jugador.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
* @class PlayerHealth
* @brief Clase que maneja la salud del jugador.
*/
public class PlayerHealth : MonoBehaviour {
  /**
  * @brief Salud máxima del jugador.
  */
  public int maxHealth = 5;
  /**
  * @brief Salud actual del jugador.
  */
  public int currentHealth;
  /**
  * @brief Array de imágenes del canvas.
  */
  public GameObject[] healthPanels;
  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
    currentHealth = maxHealth;
    for (int i = 0; i < healthPanels.Length; i++) {
      healthPanels[i].SetActive(false);
    } 
    healthPanels[0].SetActive(true);
      
  }
  /**
  * @brief Función que se ejcuta cuando algún elemento colisiona con el jugador.
  * Comprueba si el objeto que ha colisionado es un enemigo para poder quitar
  * puntos de salud y mostrar el panel de vida correspondiente.
  * @param collision objeto que entra en collision.
  */
  void OnCollisionEnter(Collision collision) {
    if(collision.gameObject.tag == "Enemy") {
      TakeDamage(1);
      int index = maxHealth - currentHealth;
      if(index < healthPanels.Length) {
        healthPanels[index].SetActive(true);
      }
    }
  }
  /**
  * @brief Función que se ejecuta en cada frame
  * Comprueba si el enemigo esta vivo, en caso contrario se muestra el menu.
  */
  void Update() {
    if(currentHealth <= 0) {
      Application.Quit();
    }
  }
  /**
  * @brief Función que quita puntos de vida del jugador.
  */
  void TakeDamage(int damage) {
    currentHealth -= damage;
  }
}
