/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se encarga de controlar el sonido del juego
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class SoundGameManager
* @brief Clase encargada de gestionar el sonido del juego
*/
public class SoundGameManager : MonoBehaviour {
  /**
  * @brief Representa la fuente de audio
  */
  private AudioSource audio;

  /**
  * @brief Es el clip de la música principal
  */
  public AudioClip mainMusic;
  
  /**
  * @brief Inicialización de los atributos necesarios
  *        Se pausa el audio del menú y se reproduce el del juego
  */
  void Start() {        
    SoundManager.Instance.gameObject.GetComponent<AudioSource>().Pause();
    audio = GetComponent<AudioSource>();
    audio.PlayOneShot(mainMusic, 0.7F);
  }
}
