using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public Transform player;
    public Transform respawnPoint;

    void Start() {
        player.transform.position = respawnPoint.transform.position;
    }
}
