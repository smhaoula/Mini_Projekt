using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float speed = 3f; 
    Vector3 bewegung = Vector3.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)){
            bewegung = Vector3.forward;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
            bewegung = Vector3.back;
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            bewegung = Vector3.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            bewegung = Vector3.left;
        }
        transform.Translate(bewegung * speed * Time.deltaTime);
    }
}
