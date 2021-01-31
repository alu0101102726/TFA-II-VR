/** Universidad de La Laguna
 * Escuela Superior de Ingeniería y Tecnología
 * Grado en Ingeniería Informática
 * Asignatura: Interfaces Inteligentes
 * Curso: 4º
 * Práctica final: TFA VR
 * @author Carlos Díaz Calzadilla <alu0101102726@ull.edu.es>
 * @author Manuel Andrés Carrera Galafate <alu0101132020@ull.edu.es>
 * @author Victoria Montserrat Manrique Rolo <alu0101122083@ull.edu.es>
 * @brief En este fichero se recogen las funciones para recoger los objetos
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
* @class PickUpObjects
* @brief Clase encargada de gestionar la recogida de objetos
*/
public class PickUpObjects : MonoBehaviour {
  /**
  * @brief Objeto que se va a recoger
  */
  public GameObject ObjectToPickUp;

  /**
  * @brief Objeto que ha recogido
  */
  public GameObject PickedObject;

  /**
  * @brief Zona de interacción (rango donde el jugador puede coger objetos)
  */
  public Transform interactionZone;

  /**
  * @brief Panel de ayuda de la linterna
  */
  public GameObject helpLanternPanel;

  /**
  * @brief Panel de ayuda de la brújula
  */
  public GameObject helpCompassPanel;

  /**
  * @brief Texto de ayuda de la linterna
  */
  public Text helpText;

  /**
  * @brief Texto de ayuda de la brújula
  */
  public Text helpTextCompass;

  /**
  * @brief Representa la fuente de audio
  */
  private AudioSource audioLantern;

  /**
  * @brief Representa la fuente de audio
  */
  private AudioSource audioCompass;

  /**
  * @brief Audio de recogida de la linterna
  */
  public GameObject speakerLantern;

  /**
  * @brief Audio de recogida de la brújula
  */
  public GameObject speakerCompass;
  
  /**
  * @brief Representa al objeto de la cámara
  */
  private GameObject camera;

  /**
  * @brief Inicialización de los atributos necesarios
  */
  void Start() {
      helpLanternPanel.SetActive(false);
      helpCompassPanel.SetActive(false);
      audioLantern = speakerLantern.GetComponent<AudioSource>();
      audioCompass = speakerCompass.GetComponent<AudioSource>();        
      camera = GameObject.Find("Main Camera");
  }

  /**
  * @brief Función que se ejecuta en cada frame
  *        Aquí se comprueban los diferentes objetos recogibles, entre ellos
  *        tenemos la linterna y la brújula. Además de eso, una vez recogidos
  *        se colocan en las posiciones definidas. Por otro lado, tenemos las
  *        cintas que son objetos especiales que permiten reproducir su sonido
  */
  void Update() {
    if(ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true) {
      if(Input.GetButtonDown("TakeItem")) {
        PickedObject = ObjectToPickUp;

        if (PickedObject.tag == "Tape") {
          PickedObject.GetComponent<PickableObject>().PlayTape();
          if(PickedObject.GetComponent<PickableObject>().isSpecial) {
            PickedObject.GetComponent<PickableObject>().activableTrigger.SetActive(true);
          }
        }
        else {
          PickedObject.GetComponent<PickableObject>().isPickable = false;
          PickedObject.transform.SetParent(camera.transform);
          Vector3 PO = camera.transform.position;
          Vector3 Ip = Vector3.Lerp(PO, interactionZone.position, 0);
          if (PickedObject.tag == "Linterna") {
            PickUpLantern(helpLanternPanel, helpText);     
            PickedObject.transform.rotation = camera.transform.rotation;
            PickedObject.transform.position = Ip;
            PickedObject.transform.Translate(-0.3f, -0.2f, 0.2f);
          }
          
          PickedObject.GetComponent<Rigidbody>().useGravity = false;
          PickedObject.GetComponent<Rigidbody>().isKinematic = true;
          if (PickedObject.tag == "Brujula") {
            PickUpCompass(helpCompassPanel, helpTextCompass);
            PickedObject.SetActive(false);
            PickedObject.transform.rotation = camera.transform.rotation;
            PickedObject.transform.position = Ip;
            PickedObject.transform.Translate(0, -0.2f, 0.8f);
            PickedObject.transform.Rotate(90, 180, 0);
          }
        }
      }
    }
  }

  /**
  * @brief Función llamada al recoger la linterna que muestra el mensaje de
  *        ayuda al jugador y reproduce el audio
  * @param panel Representa el panel donde se imprime el texto
  * @param help Texto de ayuda que se va a mostrar
  */
  void PickUpLantern(GameObject panel, Text help) {
    panel.SetActive(true);
    help.text = "Enhorabuena, has encontrado la linterna \n";
    help.text += "Ahora pulsando el botón O puedes \n encenderla o apagarla";
    help.text += ", pero cuidado \n los monstruos  sabrán que estás aquí \n y vendrán a por tí \n";
    audioLantern.Play(0);
  }
  
  /**
  * @brief Función llamada al recoger la brújula que muestra el mensaje de
  *        ayuda al jugador y reproduce el audio
  * @param panel Representa el panel donde se imprime el texto
  * @param help Texto de ayuda que se va a mostrar
  */
  void PickUpCompass(GameObject panel, Text help) {
    panel.SetActive(true);
    help.text = "¿Una brújula? \n";
    help.text += "Prueba a pulsar el D para sacarla, \n ahora te vas a poder orientar";
    help.text += "A lo mejor con este objeto\n no corres la misma suerte que yo... \n";
    audioCompass.Play(0);
  }

  /**
  * @brief Función para aceptar el mensaje del panel de la linterna
  */
  public void PulseAceptarLanternPanel() {
    helpLanternPanel.SetActive(false);
    audioLantern.Pause();
  } 
  
  /**
  * @brief Función para aceptar el mensaje del panel de la brújula
  */
  public void PulseAceptarCompassPanel() {
    helpCompassPanel.SetActive(false);
    audioCompass.Pause();
  } 
}
