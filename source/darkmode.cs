using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class darkmode : MonoBehaviour
{
    public Image dark;
    public Slider darkmode_slider;
    // Start is called before the first frame update

    void Start(){
        GameObject darkmode = GameObject.Find("darkmode");
        float brightness = PlayerPrefs.GetFloat("brightness");
        darkmode_slider.value = brightness;
    }
    void Update(){
        GameObject darkmode = GameObject.Find("darkmode");
        if(darkmode != null){
            brightness();
        }
    }
    public void brightness(){
        GameObject darkmode = GameObject.Find("darkmode");
        Image dark = darkmode.GetComponent<Image>();

        Color dark_plane = dark.color;
        dark_plane.a = darkmode_slider.value;
        dark.color = dark_plane;
        Debug.Log(darkmode_slider.value);
        PlayerPrefs.SetFloat("brightness", darkmode_slider.value);
    }
}
