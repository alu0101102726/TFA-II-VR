using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerStair : MonoBehaviour {
    public string sceneName;
    public int sceneCode;
    
    private void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Player") {
            GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lastRoom = sceneCode;
            SceneManager.LoadScene(sceneName);
        }
    }

}
