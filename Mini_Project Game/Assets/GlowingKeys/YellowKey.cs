using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKey : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(0, 50*Time.deltaTime, 0);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
