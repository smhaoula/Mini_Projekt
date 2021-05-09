using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomScript : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    float speed = 4f;
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
