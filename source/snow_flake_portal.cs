using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snow_flake_portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("portal"))
        {
            if(SceneManager.GetActiveScene().name == "grass scene"){
                SceneManager.LoadSceneAsync("snow scene");
                SceneManager.UnloadSceneAsync("grass scene");
                //SceneManager.LoadScene("snow scene", LoadSceneMode.Additive);
                Debug.Log("loaded snow scene");
            }
            if(SceneManager.GetActiveScene().name == "snow scene"){
                SceneManager.LoadSceneAsync("level 3");
                SceneManager.UnloadSceneAsync("snow scene");
            }
            if(SceneManager.GetActiveScene().name == "level 3"){
                SceneManager.LoadSceneAsync("level 4");
                SceneManager.UnloadSceneAsync("level 3");
            }
            if(SceneManager.GetActiveScene().name == "level 4"){
                SceneManager.LoadSceneAsync("level 5");
                SceneManager.UnloadSceneAsync("level 4");
            }
            if(SceneManager.GetActiveScene().name == "level 5"){
                SceneManager.LoadSceneAsync("end");
                SceneManager.UnloadSceneAsync("level 5");
            }
        }   
    }

}
