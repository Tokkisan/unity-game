using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loader_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float volume = PlayerPrefs.GetFloat("volume");
        float brightness = PlayerPrefs.GetFloat("brightness");

        PlayerPrefs.SetFloat("volume", volume); 
        PlayerPrefs.SetFloat("brightness", brightness);
    }

}

