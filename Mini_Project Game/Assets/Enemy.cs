using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public HealthBar healthBar;

    public float fireRate;
    public float nextFire;

    public Transform target;
    public Vector3 offset = new Vector3(0,0,1);
    public Vector3 FireVelocity = new Vector3(0, 1, 6);
    public GameObject bullet;
    public GameObject bulletSpawnPoint;

    void Start(){
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        fireRate = 2f;
        nextFire = Time.time;
    }
    void Update()
    {
        if(currentHealth <= 0){
            Destroy(gameObject, 0.5f);
        }


        if(Vector3.Distance(transform.position, target.position) <= 10){
            transform.LookAt(target);
            if(Time.time > nextFire)
            {
                Shoot();
            }
        }
    }

    void Shoot(){
        var direction = transform.rotation;
        var projectile = Instantiate(bullet.transform, bulletSpawnPoint.transform.position + direction*offset, direction);
        //Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        if (projectile.TryGetComponent<Rigidbody>(out var rigidbody))
        {
            rigidbody.velocity = direction * FireVelocity;
        }

        nextFire = Time.time + fireRate;
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if(bullet != null){
            currentHealth = currentHealth - 5;
            healthBar.SetHealth(currentHealth);

        }
        
    }
}
