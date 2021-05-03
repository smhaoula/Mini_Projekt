using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explosion;
    void OnCollisionEnter(Collision collision){
        var exp = Instantiate(explosion, transform.position, transform.rotation);
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        Destroy(exp, 2f);
    }
}
