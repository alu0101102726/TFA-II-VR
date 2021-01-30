/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se encarga de gestionar los distintos objetos de lal escenas
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class ObjectsManager
* @brief Clase encargada de gestionar los objetos
*/
public class ObjectsManager : MonoBehaviour {
  /**
  * @brief Representa el objeto linterna
  */
  public GameObject lantern;

  /**
  * @brief Representa el objeto brújula
  */
  public GameObject compass;

  /**
  * @brief Función que se ejecuta en cada frame
  *        Permite usar al jugador la linterna y la brújula
  */
  void Update() {
    if(Input.GetButtonDown("UsarLinterna")) {
      lantern.GetComponent<Animation>().Play("Switch_CuboAction");
      lantern.GetComponent<Light>().enabled = !lantern.GetComponent<Light>().enabled;
    }

    if(Input.GetButtonDown("UsarBrujula")) {
      compass.SetActive(!compass.activeSelf);
      compass.GetComponent<Animation>().Play("Open_brujula");
    }
  }
}
