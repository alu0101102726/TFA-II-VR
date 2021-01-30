/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recoge la gestión del spawn del jugador
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class SpawnManager
* @brief Clase encargada de gestionar el spawn del jugador
*/
public class SpawnManager : MonoBehaviour {
  /**
  * @brief Transform del jugador
  */
  public Transform player;

  /**
  * @brief Punto del respawn del jugador
  */
  public Transform respawnPoint;

  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
    player.transform.position = respawnPoint.transform.position;
  }
}
