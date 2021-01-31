/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones que permiten al jugador
 * disparar.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
* @class Shoot
* @brief Clase que permite dispara al jugador.
*/
public class Shoot : MonoBehaviour {
  /**
  * @brief Referencia a la bala.
  */
  public Rigidbody currentAmmo;
  /**
  * @brief Velocidad de la bala.
  */
  public float speed = 100f;
  /**
  * @brief Componente que permite reproducir audio.
  */
  private AudioSource audio;
  /**
  * @brief Sonido de disparo.
  */
  public AudioClip shootSound;
  /**
  * @brief Sonido de recarga.
  */
  public AudioClip reloadSound;
  /**
  * @brief Cantidad de munción
  */
  private int ammo;
  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {        
    audio = GetComponent<AudioSource>();
    ammo = 7;
  }
  /**
  * @brief Función que hace la recarga de la pistola.
  */
  void Reload() {
    audio.PlayOneShot(reloadSound, 0.5F);
    ammo = 7;
  }
  /**
  * @brief Función que hace que la pistola dispare.
  */
  void Disparar() {
    Vector3 ammoPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    Rigidbody ammoClone = (Rigidbody) Instantiate(currentAmmo, ammoPosition, currentAmmo.rotation);
    ammoClone.velocity = transform.forward * (-speed);
    ammo--;
  }
  /**
  * @brief Función que se ejecuta en cada frame
  * Se comprueba si el jugador ha pulsado el botón de disparar o recargar
  * para hacer la acción necesaria.
  */
  void Update() {
    if((Input.GetButtonDown("Shoot") || Input.GetKeyDown(KeyCode.F)) && ammo > 0) {
      audio.PlayOneShot(shootSound, 0.5F);
      Disparar();
    }
    if(Input.GetButtonDown("Reload") || Input.GetKeyDown(KeyCode.R)) {
      Reload();
    }
  }
}
