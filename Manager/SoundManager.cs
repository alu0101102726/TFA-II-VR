/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se gestiona los efectos y el sonido del menú principal
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* @class SoundManager
* @brief Clase encargada de gestionar el audio del menú y efectos
*/
public class SoundManager : MonoBehaviour {
  /**
  * @brief Intancia global del audio
  */
  private static SoundManager instance = null;

  /**
  * @brief Intancia global del audio
  */
  public static SoundManager Instance {get {return instance; } }
  
  /**
  * @brief Representa la fuente de audio
  */
  private static AudioSource audio;

  /**
  * @brief Representa el clip de la musica principal
  */
  public AudioClip mainMusic;

  /**
  * @brief Representa la música del click
  */
  public AudioClip clickAudio;

  /**
  * @brief Función Awake, se ejecuta antes de la función Start. 
  *        Se comprueba si ya hay musica sonando y se evita que
  *        se destruya entre escenas (para menú de opciones, etc)
  */
  void Awake() {
    if (instance != null && instance != this) {
        return;
    }
    else {
        instance = this;
    }
    DontDestroyOnLoad(this.gameObject);
  }

  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
    audio = GetComponent<AudioSource>();
    if (!audio.isPlaying) {
        audio.PlayOneShot(mainMusic, 0.7F);
    }
  }

  /**
  * @brief Se inicia el clip del sonido de click
  */
  public void PlaySonidoClick() {
    audio.PlayOneShot(clickAudio, 1.0F);
  }
}
