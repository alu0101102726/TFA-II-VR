/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones que controlaran la
 * salud del enemigo.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* @class EnemyHealth
* @brief Clase encargada de controlar la salud de los enemigos
*/
public class EnemyHealth : MonoBehaviour {
  /**
    * @brief Vida máxima del enemigo
    */
  public int maxHealth = 100;
  /**
  * @brief Vida actual del enemigo
  */
  public int currentHealth;
  /**
  * @brief Objeto "Bala"
  */
  public GameObject bullet;
  /**
  * @brief Booleano, representa si estamos en misión o no
  */
  public bool isMision;
  /**
  * @brief Referencia a la clase LogicaNPC
  */
  public LogicaNPC logicNPC;
  /**
  * @brief Sonido de muerte
  */
  public AudioClip audioDeath;
  /**
  * @brief Sonido de recibir daño
  */
  public AudioClip audioHurt;
  /**
  * @brief Componente que se encarga de reproducir audio
  */
  private AudioSource audio;

  /**
  * @brief Función Start, asigna la salud actual del enemigo y el componente
  * y el componente de reproducción de audio.
  */
  void Start() {
      currentHealth = maxHealth;
      audio = GetComponent<AudioSource>();
  }
  /**
  * @brief Función que detecta las colisiones hechas con el enemigo
  * @param collision objeto de tipo collision
  */
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

  /**
  * @brief Función que resta la cantidad de salud actual segun el daño
  * recibido.
  * @param damage daño recibido.
  */
  void TakeDamage(int damage) {
      currentHealth -= damage;
  }
}