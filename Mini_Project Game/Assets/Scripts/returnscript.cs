using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnscript : MonoBehaviour
{
    [SerializeField]
    Transform newtarget;
    [SerializeField]
    public AtomScript atomscript;
    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Ball")
        {
            atomscript.target = newtarget;
        }
    }
}
