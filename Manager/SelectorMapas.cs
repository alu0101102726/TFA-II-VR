using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorMapas : MonoBehaviour {
    public void Mapa1() {
        SceneManager.LoadScene("Game - Nivel 1");
    }
    
    public void Mapa2() {
        SceneManager.LoadScene("Game - Nivel 2");
    }
    
    public void Mapa3() {
        SceneManager.LoadScene("Game - Nivel 3");
    }
}
