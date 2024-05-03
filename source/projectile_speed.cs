using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_speed : MonoBehaviour
{

    public float speed = 2f;
    public float time = 5.0f;
    private Rigidbody2D rb;
    public GameObject fire_clone;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        fire_clone = GameObject.Find("fire_bullet(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(fire_clone, time);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("ground")){
            Destroy(fire_clone);
        }

    }
}
