using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class button : MonoBehaviour
{

    // Start is called before the first frame update
    public void PlayBtn() {
        Debug.Log("button has been clickled");
        SceneManager.LoadSceneAsync("grass scene");
        SceneManager.UnloadSceneAsync("main menu");
        


    }

    //use for home button and from settings back to main menu 
    //hopefully this works
    public void Main_menu_btn(){
        SceneManager.LoadScene("main menu");
    }

    public void Settings() {
        SceneManager.LoadSceneAsync("settings");
        SceneManager.UnloadSceneAsync("main menu");
        
    }

    public void quit() {
        Application.Quit();
    }
}
