using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicaNPC : MonoBehaviour {
    public GameObject simbolMision;
    public PlayerMove jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public Text textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numObjetivos;
    public GameObject botonMision;

    void Start() {
        numObjetivos = objetivos.Length;
        textoMision.text = "Mata a 5 Zombunnys \n Restantes: " + numObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        simbolMision.SetActive(true);
        panelNPC.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.X) && !aceptarMision) {
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            jugadorCerca = true;
            if (!aceptarMision) {
                panelNPC.SetActive(true);
            }
        }

    }

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
