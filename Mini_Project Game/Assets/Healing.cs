using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
