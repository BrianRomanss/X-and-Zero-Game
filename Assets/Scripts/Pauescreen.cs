using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pauescreen : MonoBehaviour
{
    private Gamemanager gamemanager;
    private Main_Menu main_Menu;
    [SerializeField] Image pausescreenPanel;
    
    void Start()
    {
        gamemanager= GetComponent<Gamemanager>();
        main_Menu= GetComponent<Main_Menu>();
        
    }

    public void openPauseScreen(){
        pausescreenPanel.gameObject.SetActive(true);
       
        
        
    }
    public void OnResume(){
         pausescreenPanel.gameObject.SetActive(false);
    }
    public void OnRestart(){
        pausescreenPanel.gameObject.SetActive(false);
        gamemanager.Restart();
    }
    public void OnExit(){
        pausescreenPanel.gameObject.SetActive(false);
        main_Menu.Mainmenu_Panel.gameObject.SetActive(true);
        main_Menu.play_Button.gameObject.SetActive(true);
        gamemanager.Restart();
    }
}
