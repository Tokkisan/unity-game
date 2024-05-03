using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class spike_dmg : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("spike"))
        {
            Destroy(this.gameObject);
            Debug.Log("dead");
        }
    }
}
