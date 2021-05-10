using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorlevel2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {


            if (other.GetComponent<Movement>().HasYellowKey())
            {
                GetComponent<Animator>().enabled = true;
            }
        }
    }


}
