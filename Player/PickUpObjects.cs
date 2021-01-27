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
            if(Input.GetKeyDown(KeyCode.C)) {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false;
                PickedObject.transform.SetParent(camera.transform);
                Vector3 PO = camera.transform.position;
                Vector3 Ip = Vector3.Lerp(PO, interactionZone.position, 0);
                if (PickedObject.tag == "Linterna") {
                    PickUpLantern(helpLanternPanel, helpText);     
                    PickedObject.transform.rotation = camera.transform.rotation;
                    PickedObject.transform.position = Ip;
                    PickedObject.transform.Translate(-2, 0, 3);
                }
                
                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                if (PickedObject.tag == "Brujula") {
                    PO = new Vector3(camera.transform.position.x - 0.1f, camera.transform.position.y, camera.transform.position.z + 0.8f);
                    PickUpCompass(helpCompassPanel, helpTextCompass);
                    PickedObject.SetActive(false);
                    PickedObject.transform.position = Ip;
                    PickedObject.transform.Translate(-0.5f, 0, 1);
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
