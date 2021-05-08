using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject explosion;
    public GameObject exp;

    void Start()
    {
        exp = Instantiate(explosion, transform.position, transform.rotation);
        exp.transform.parent = gameObject.transform;
    }
    void OnCollisionEnter(Collision collision){
        //Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        Destroy(exp, 2f);
    }
}
