using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimeBullet : MonoBehaviour {
    public float maxLifeTime;
    void Start () {
            Destroy(gameObject, maxLifeTime);
    }
}
