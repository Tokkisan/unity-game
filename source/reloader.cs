using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class reloader : MonoBehaviour
{
    public Text deadtext;
    public string active_scene;
    void Start()
    {
        //getting only the text component
        deadtext = GetComponent<Text>();
        
    }
    // Update is called once per frame
    void Update()
    {
        //restart game to first scene
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("reloaded");
            active_scene = SceneManager.GetActiveScene().name;
            SceneManager.LoadSceneAsync(active_scene);
        }
        //turns on the component for Dead text
        if (GameObject.Find("player") == null)
        {
            Debug.Log("dead");
            deadtext.enabled = true;
        }
    }
}
