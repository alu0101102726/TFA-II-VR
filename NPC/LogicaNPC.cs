/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones referentes al NPC
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* @class LogicaNPC
* @brief Clase que maneja las funcionalidades del NPC
*/
public class LogicaNPC : MonoBehaviour {
  /**
  * @brief Símbolo de alerta.
  */
  public GameObject simbolMision;
  /**
  * @brief Referencia a la clase PlayerMove
  */
  public PlayerMove jugador;
  /**
  * @brief Referencia a un panel del Canvas
  */
  public GameObject panelNPC;
  /**
  * @brief Refenrencia a un panel de
  */
  public GameObject panelNPC2;
  /**
  * @brief Referencia al panel del canvas con las descripcion de la mision.
  */
  public GameObject panelNPCMision;
  /**
  * @brief Referencia a un texto del canvas.
  */
  public Text textoMision;
  /**
  * @brief Booleano que controla la distancia entre el jugador y el NPC
  */
  public bool jugadorCerca;
  /**
  * @brief Booleano que controla si se ha aceptado la misión o no
  */
  public bool aceptarMision;
  /**
  * @brief Array de objetivos.
  */
  public GameObject[] objetivos;
  /**
  * @brief Número de objetivos
  */
  public int numObjetivos;
  /**
  * @brief Referencia al botón de aceptar misión.
  */
  public GameObject botonMision;
  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
    numObjetivos = objetivos.Length;
    textoMision.text = "Mata a 5 Zombunnys \n Restantes: " + numObjetivos;
    jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    simbolMision.SetActive(true);
    panelNPC.SetActive(false);
  }
  /**
  * @brief Función que se ejecuta en cada frame
  *  Comprueba si se ha pulsado el botón "X".
  */
  void Update() {
    if(Input.GetKeyDown(KeyCode.X) && !aceptarMision) {
      panelNPC.SetActive(false);
      panelNPC2.SetActive(true);
    }
  }
  /**
  * @brief Función que se ejecuta cuando se entra en el collider del NPC.
  * @param other objeto que entra en el collider.
  */
  private void OnTriggerEnter(Collider other) {
    if (other.tag == "Player") {
      jugadorCerca = true;
      if (!aceptarMision) {
        panelNPC.SetActive(true);
      }
    }

  }
  /**
  * @brief 
  */
  private void OnTriggerExit(Collider other) {
    if (other.tag == "Player") {
      jugadorCerca = true;
      panelNPC.SetActive(false);
      panelNPC2.SetActive(false);
    }
  }

  public void PulseNo() {
    panelNPC2.SetActive(false);
    panelNPC.SetActive(true);
  } 
    
  public void PulseAceptar() {
    panelNPC2.SetActive(false);
    panelNPC.SetActive(false);
    panelNPCMision.SetActive(false);
  } 

  public void PulseYes() {
    aceptarMision = true;
    for(int i = 0; i < objetivos.Length; i++) {
      objetivos[i].SetActive(true);
    }
    jugadorCerca = false;
    simbolMision.SetActive(false);
    panelNPC.SetActive(false);
    panelNPC2.SetActive(false);
    panelNPCMision.SetActive(true);
  }

}
