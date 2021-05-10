using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            GameObject.Find("Player").GetComponent<Movement>().GameOver();
        }
    }
}
