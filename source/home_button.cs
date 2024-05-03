using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home_button : MonoBehaviour
{
    // Start is called before the first frame update
    private Scene savedlvl;
    private int lvl;

    void Awake(){
        lvl = PlayerPrefs.GetInt("SavedLVL", 0);
    }

    public void Main_menu(){
        SceneManager.LoadSceneAsync("main menu");
        Debug.Log(savedlvl);
    }

    public void SaveLVL(){
        savedlvl = SceneManager.GetActiveScene();
        if (savedlvl.name == "grass scene"){
            Debug.Log("saving grass scene");
            lvl = 1;
        }
        if(savedlvl.name == "snow scene"){
            Debug.Log("saving snow scene");
            lvl = 2;
        }
        if(savedlvl.name == "level 3"){
            lvl = 3;
        }

        PlayerPrefs.SetInt("SavedLVL", lvl);
        PlayerPrefs.Save();
    }

    public void Loadlvl(){
        Debug.Log(lvl);
        if(lvl == 1){
            SceneManager.LoadSceneAsync("grass scene");
        }
        if(lvl == 2){
            SceneManager.LoadSceneAsync("snow scene");
        }
        if(lvl == 3){
            SceneManager.LoadSceneAsync("level 3");
        }
    }
}
