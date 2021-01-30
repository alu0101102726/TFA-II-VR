/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se gestionan los clips que emiten los altavoces
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class SpeakerManager
* @brief Clase encargada de gestionar los sonidos de los altavoces
*/
public class SpeakerManager : MonoBehaviour {
  /**
  * @brief Representa la fuente de audio
  */
  private AudioSource audioClip;
  
  /**
  * @brief Representa el clip que va a emitir el altavoz
  */
  public GameObject speakerClip;
  
  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {  
    audioClip = speakerClip.GetComponent<AudioSource>();
  }

	/**
	* @brief Función que detecta si el jugador ha pasado el trigger
  *        para poder reproducir el sonido
	* @param collider Objeto con el que se colisiona
	*/
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      audioClip.Play();
      gameObject.SetActive(false);
    }
  }
}