using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;



public class element : MonoBehaviour
{
    // Start is called before the first frame update
    public Color player_color;
    public Color fire_element = new Color(255, 0, 0);
    public Color water_element = new Color(0, 0, 255);
    public Color normal = new Color(0,0,0);
    public Color earth_element = new Color (0, 255, 0);
    public TilemapCollider2D DWactive;
    public GameObject deepwater;
    public GameObject player;
    private Rigidbody2D rb;
    private float gravityScale = 0.5f;
    public float earth_cooldown = 0.0f;
    void Start()
    {

        deepwater = GameObject.Find("deepwater");
        if(deepwater != null){
            DWactive = deepwater.GetComponent<TilemapCollider2D>();
            DWactive.enabled = true;
        }
        player = this.gameObject;
        if(player != null){
            rb = player.GetComponent<Rigidbody2D>();
            Debug.Log("got player body");
            if(rb != null){
                rb.gravityScale = gravityScale;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        player = this.gameObject;

        earth_cooldown -= Time.deltaTime;
        if(Input.GetKey(KeyCode.K)){
            Debug.Log("K was pressed");
            //black normal
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = new Color(0, 0, 0);    
        }
        if(Input.GetKey(KeyCode.J)){
            Debug.Log("J was pressed");
            //red fire
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        if(Input.GetKey(KeyCode.I)){
            //blue water
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = new Color (0, 0, 255);
        }
        if(Input.GetKey(KeyCode.L)){
            //green earth
            GameObject.Find("player").GetComponent<SpriteRenderer>().color = new Color (0, 255, 0);
        }
        player_color = GameObject.Find("player").GetComponent<SpriteRenderer>().color;


        if (player_color == earth_element)
        {
            if (Input.GetKeyDown(KeyCode.N) && earth_cooldown <= 0f)
            {
                //rb.gravityScale *= -1;
                Debug.Log("n was pressed");
                if(Mathf.Approximately(rb.gravityScale, -0.5f))
                {
                    rb.gravityScale = 0.5f;
                    player.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    Debug.Log("Gravity Scale: " + rb.gravityScale);
                    Debug.Log("Rotation: " + player.transform.rotation.eulerAngles.z);
                    earth_cooldown = 4.0f;
                }
                else if (Mathf.Approximately(rb.gravityScale, 0.5f))
                {
                    rb.gravityScale = -0.5f;
                    player.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                    Debug.Log("Gravity Scale: " + rb.gravityScale);
                    Debug.Log("Rotation: " + player.transform.rotation.eulerAngles.z);
                    earth_cooldown = 4.0f;
                }
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("water") || other.CompareTag("deepwater")){
            if(player_color == fire_element){
                Destroy(player);
            }
    }
    }
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("deepwater")){
            if(player_color == water_element){
                DWactive.enabled = false;
            }
            if(player_color != water_element){
                DWactive.enabled = true;
            }
        }
    }
}
