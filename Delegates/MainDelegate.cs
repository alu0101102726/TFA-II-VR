/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones que van a ser implementadas
 *       y gestionadas por el delegado.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class MainDelegate
* @brief Clase encargada de gestionar los delegados
*/
public class MainDelegate : MonoBehaviour {
  /**
  * @brief Declaración del delegado
  */
  public delegate void enemyMove();

  /**
  * @brief Declaración del evento de movimiento del enemigo
  */
  public event enemyMove enemyMoveEvent;

  /**
  * @brief Referencia al jugador
  */
  public GeneralPlayer player;

  /**
  * @brief Suscripción al delegado del jugador
  */
  void Start()
  {
      player.enemyMoveEvent += start_movement;
  }

  /**
  * @brief Evento de movimiento
  */
  void start_movement(){
      if(enemyMoveEvent != null){
          enemyMoveEvent();
      }
  }
}

