using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    void Start() {
        int spawnVal = GameObject.FindWithTag("Player").GetComponent<PlayerMove>().lastRoom;        
    }
}
