/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones que van a gestionar aquellos
 *        objetos que son recogibles
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* @class PickableObject
* @brief Clase encargada de gestionar los objetos recogibles
*/
public class PickableObject : MonoBehaviour {
  /**
  * @brief Variable boobleana que marca si un objeto es recogible o no
  */
  public bool isPickable = true;

  /**
  * @brief Variable boobleana que marca si un objeto es especial o no
  *        esto se usa para los cassete que son objetos que solo se pueden
  *        reproducir, pero no coger
  */
  public bool isSpecial = false;
  
  /**
  * @brief Representa la fuente de audio
  */
  private AudioSource audio;
  
  /**
  * @brief Representa el trigger que va a activar un evento especial
  */
  public GameObject activableTrigger;
  
  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
    if(GetComponent<AudioSource>() != null) {
      audio = GetComponent<AudioSource>();
    }
  }
  
  /**
  * @brief Si el objeto entra en la zona de interacción, se añade como
  *        un objeto recogible
  */
  private void OnTriggerEnter(Collider other) {
    if(other.tag == "PlayerInteractionZone") {
      other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = this.gameObject;
    }
  }

  /**
  * @brief Si el objeto sale de la zona de interacción, se elimina como
  *        un objeto recogible
  */
  private void OnTriggerExit(Collider other) {
    if(other.tag == "PlayerInteractionZone") {
      other.GetComponentInParent<PickUpObjects>().ObjectToPickUp = null;
    }
  }

  /**
  * @brief Permite reproducir el audio de la cinta
  */
  public void PlayTape() {
    print("Play audio");
    audio.Play();
  }
}
