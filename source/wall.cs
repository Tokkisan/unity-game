using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("fireball")) {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
