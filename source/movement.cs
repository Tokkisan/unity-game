using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class movementtesting : MonoBehaviour
{
    public float thrust = .05f;
    public float thrust2 = -.05f;
    public float jumpForce = 1.25f;
    private bool jump = false;
    public float jump_counter = 0;
    public float max_thrust = 3f;
    public Rigidbody2D Rb;
    public Color player_color;
    public Color water_element = new Color(0,0,255);
    public AudioClip jumpsound;
    private AudioSource audioS;

    private bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        audioS = GetComponent<AudioSource>();
        if(audioS == null){
        audioS = gameObject.AddComponent<AudioSource>();
        }
    }
    void Update()
    {
        //poll input, set "cur input direction"
        // if statement checks jump_counter to stop people from inf jumping
        if(Input.GetKeyDown(KeyCode.Space) && jump == false && jump_counter < 3)
        {   
            Debug.Log("Space was pressed");
            Rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            audioS.PlayOneShot(jumpsound);
            jump_counter++;
            if(jump_counter == 2)
            {
            jump = true;
            }
        } 
        if (Input.GetKeyDown(KeyCode.Escape)){
            Pause();
            Debug.Log("escape was pressed");
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {

        if(other.gameObject.CompareTag("ground"))
        {
            jump = false;
            jump_counter = 0;
        }
        //stop double jumping when on ice by adding 1 to the counter when on ice
        if(other.gameObject.CompareTag("ice")) {
            jump = false;
            jump_counter = 1;
        }
    }


    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Apply cur input direction
        if(Input.GetKey(KeyCode.A))
        {
            Debug.Log("A was pressed");
            //Rb.MovePosition(Rb.position+Vector2.left*Time.deltaTime);
            Rb.AddForce(transform.right * -thrust, ForceMode2D.Impulse);
            Rb.velocity = Vector2.ClampMagnitude(Rb.velocity, max_thrust);
            Debug.Log(Rb.velocity);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Debug.Log("D was pressed");
            Rb.AddForce(transform.right * thrust, ForceMode2D.Impulse);
            Rb.velocity = Vector2.ClampMagnitude(Rb.velocity, max_thrust);
            Debug.Log(Rb.velocity);
        }
    }



    public void Pause(){
        paused = !paused;
        if(paused){
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }

    }
}
