/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se encarga de gestionar el cambio del jugador entre escenas
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class EstadoJuego
* @brief Clase que gestiona el cambio del jugador entre escenas
*/
public class EstadoJuego : MonoBehaviour {
  
  /**
  * @brief Declaración del estado de juego como estático
  */
  public static EstadoJuego estadoJuego;

  /**
  * @brief Función Awake, se ejecuta antes de la función Start. 
  *        Evita que el jugador se destruya entre escenas 
  */
  void Awake() {
    if(estadoJuego == null) {
      estadoJuego = this;
      DontDestroyOnLoad(gameObject);
    }
    else if(estadoJuego != this) {
      Destroy(gameObject);
    }
  }
}
