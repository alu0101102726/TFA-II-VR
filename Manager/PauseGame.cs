using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.G)) 
        {
            if (!pausePanel.activeInHierarchy) 
            {
                pausegame();
            }
            if (pausePanel.activeInHierarchy) 
            {
                 continuegame();
            }
        } 
     }
    private void pausegame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        //Disable scripts that still work while timescale is set to 0
    } 
    private void continuegame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        //enable the scripts again
    }
}