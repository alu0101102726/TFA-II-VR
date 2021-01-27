using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsManager : MonoBehaviour {
    public GameObject lantern;
    public GameObject compass;

    void Update() {
        if(Input.GetKeyDown(KeyCode.Q)) {
            lantern.GetComponent<Animation>().Play("Switch_CuboAction");
            lantern.GetComponent<Light>().enabled = !lantern.GetComponent<Light>().enabled;
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            compass.SetActive(!compass.activeSelf);
            compass.GetComponent<Animation>().Play("Open_brujula");
        }
    }
}
