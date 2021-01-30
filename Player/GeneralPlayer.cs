/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero representará en jugaro en su conjunto.
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @class GeneralPlayer
* @brief Clase representa al jugador.
*/
public class GeneralPlayer : MonoBehaviour{
  /**
  * @brief Declaración de delegado.
  */   
  public delegate void enemy();
  /**
  * @brief Declaración del evento.
  */
  public event enemy enemyMoveEvent;
  /**
  * @brief Función que se ejecuta cuando se entra en el collider del jugador
  * Si este elemento es un trigger de tipo "Wall Trigger" se llama al evento
  * de movimiento.
  * @param other elemento que entra en el collider.
  */
  void OnTriggerEnter(Collider other){
    if(other.tag == "WallTrigger"){
      if(enemyMoveEvent != null){
        enemyMoveEvent();
      }
    }
  }
}
