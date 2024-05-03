using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bgm : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void Awake()
    {
        //stop music from playing onto of each other
        GameObject[] music = GameObject.FindGameObjectsWithTag("background music");
        if (music.Length > 1){
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }


}
