using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Main_Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Button play_Button;
    public Button Settings_Button;
    public GameObject Mainmenu_Panel;
    [SerializeField] TextMeshProUGUI Titletext;
    private Gamemanager gamemanager;
    [SerializeField] List<Image> BackgroundImages;
    [SerializeField] Image currantbackground;

    
    void Start()
    {
        gamemanager = GetComponent<Gamemanager>();
       foreach (var item in BackgroundImages)
       {
        item.gameObject.SetActive(false);
       }
       Titletext.gameObject.SetActive(false);
  
    }

    public void OnButtonClick(){
        Mainmenu_Panel.gameObject.SetActive(false);
        play_Button.gameObject.SetActive(false);
        
        
    }
    public void Settings_Screen(){
      foreach (var item in BackgroundImages)
       {
        item.gameObject.SetActive(true);
       }
        play_Button.gameObject.SetActive(false);
        Settings_Button.gameObject.SetActive(false);
        Titletext.gameObject.SetActive(true);

    }
    public void OnPointerClick(GameObject clickedObject){
        Image clickedImage = clickedObject.GetComponent<Image>();
        if (clickedImage != null)
        {
            currantbackground.sprite = clickedImage.sprite;
            foreach (var item in BackgroundImages){
            item.gameObject.SetActive(false);
            }
            play_Button.gameObject.SetActive(true);
        Settings_Button.gameObject.SetActive(true);
        }
       
    }

}
