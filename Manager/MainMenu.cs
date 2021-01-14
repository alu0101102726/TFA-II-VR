using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void CambiarJuego() {
        SceneManager.LoadScene("Seleccionar Nivel");
    }

    public void CambiarOpciones() {
        SceneManager.LoadScene("Opciones");
    }

    public void Salir() {
    }
}
