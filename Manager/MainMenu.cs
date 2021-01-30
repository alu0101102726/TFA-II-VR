/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief Se establece el cambio entre las diferentes opciones del menú
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
* @class MainMenu
* @brief Clase que se encarga de gestionar el menú principal
*/
public class MainMenu : MonoBehaviour {
    
  /**
  * @brief Permite cambiar de escena desde el menú a la sala de juego
  */
  public void CambiarJuego() {
      SceneManager.LoadScene("Room 1");
  }

  /**
  * @brief Permite cambiar al menú de opciones
  */
  public void CambiarOpciones() {
      SceneManager.LoadScene("Opciones");
  }

  /**
  * @brief Permite salir del juego
  */
  public void Salir() {
      Application.Quit();
  }
}
