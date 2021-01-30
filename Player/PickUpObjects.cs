using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpObjects : MonoBehaviour
{
    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone;
    public GameObject helpLanternPanel;
    public GameObject helpCompassPanel;
    public Text helpText;
    public Text helpTextCompass;
    private AudioSource audioLantern;
    private AudioSource audioCompass;
    public GameObject speakerLantern;
    public GameObject speakerCompass;
    private GameObject camera;

    void Start() {
        helpLanternPanel.SetActive(false);
        helpCompassPanel.SetActive(false);
        audioLantern = speakerLantern.GetComponent<AudioSource>();
        audioCompass = speakerCompass.GetComponent<AudioSource>();        
        camera = GameObject.Find("Main Camera");
    }

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

    void PickUpLantern(GameObject panel, Text help) {
        panel.SetActive(true);
        help.text = "Enhorabuena, has encontrado la linterna \n";
        help.text += "Ahora pulsando el botón O puedes \n encenderla o apagarla";
        help.text += ", pero cuidado \n los monstruos  sabrán que estás aquí \n y vendrán a por tí \n";
        audioLantern.Play(0);
    }
    void PickUpCompass(GameObject panel, Text help) {
        panel.SetActive(true);
        help.text = "¿Una brújula? \n";
        help.text += "Prueba a pulsar el D para sacarla, \n ahora te vas a poder orientar";
        help.text += "A lo mejor con este objeto\n no corres la misma suerte que yo... \n";
        audioCompass.Play(0);
    }
    public void PulseAceptarLanternPanel() {
        helpLanternPanel.SetActive(false);
        audioLantern.Pause();
    } 
    public void PulseAceptarCompassPanel() {
        helpCompassPanel.SetActive(false);
        audioCompass.Pause();
    } 
}
