using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralPlayer : MonoBehaviour
{
    public delegate void enemy();
    public event enemy enemyMoveEvent;

    void OnTriggerEnter(Collider other){
        if(other.tag == "WallTrigger"){
            Debug.Log("hemos colisionado");
            if(enemyMoveEvent != null){
                enemyMoveEvent();
            }
        }
    }
}
