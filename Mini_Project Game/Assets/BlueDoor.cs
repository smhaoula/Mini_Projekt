using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player") {
        
            if(other.GetComponent<Movement>().HasBlueKey())
            {
                GetComponent<Animator>().enabled = true;
            }
            
        }
    }
}
