using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class projectile : MonoBehaviour
{
    public bool fire;
    public Color player_color;
    public Color fire_element = new Color(255, 0, 0);
    public GameObject fire_bulletPrefab;
    public Transform player;
    public GameObject new_fire;
    public float cooldown = 4.0f;
    void Update()
    {
        cooldown -= Time.deltaTime;
        player_color = GameObject.Find("player").GetComponent<SpriteRenderer>().color;
        if(player_color == fire_element){
            if (Input.GetKeyDown(KeyCode.N) && cooldown <= 0f){
                new_fire = Instantiate(fire_bulletPrefab, player.position, transform.rotation);
                cooldown = 4.0f;
            }
        }

    }


}
