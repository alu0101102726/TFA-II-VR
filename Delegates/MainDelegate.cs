using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDelegate : MonoBehaviour
{
    public delegate void enemyMove();
    public event enemyMove enemyMoveEvent;
    public GeneralPlayer player;
    // Start is called before the first frame update
    void Start()
    {
        player.enemyMoveEvent += start_movement;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void start_movement(){
        if(enemyMoveEvent != null){
            enemyMoveEvent();
        }
    }
}
