/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recoge la funcion que elimina la bala disparada
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class LifetimeBullet
* @brief Clase encargada de eliminar la bala disparada
*/
public class LifetimeBullet : MonoBehaviour {
  
  /**
  * @brief Tiempo máximo de vida de la bala
  */
  public float maxLifeTime;

  /**
  * @brief Se destruye la bala después de un tiempo
  */
  void Start () {
    Destroy(gameObject, maxLifeTime);
  }
}
