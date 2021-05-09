using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            GameObject.Find("Player").GetComponent<Movement>().GameOver();
        }
    }
}
