using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnscript : MonoBehaviour
{
    [SerializeField]
    Transform newtarget;
    [SerializeField]
     AtomScript atomscript;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") {
            atomscript.target = newtarget;
        }

    }
}
