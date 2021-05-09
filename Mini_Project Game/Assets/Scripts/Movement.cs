using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField]
    GameObject Image;
    public YellowKey yellowKey;
    public BlueKey blueKey;
    private YellowKey yellowKeyInstance;
    private BlueKey blueKeyInstance;
    public Transform spawnPoint;
    Animator _animator;
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Transform cam;
    public CharacterController controller;

    public float speed = 6f;

    public GameObject bulletSpawnPoint;
    public GameObject bullet;
    public float smooth = 0.1f;

    float turnSmoothVelocity;
    Vector3 direction;
    public Vector3 offset = new Vector3(0,0,1);
    public Vector3 FireVelocity = new Vector3(0, 0, 6);

    void Awake() => _animator = GetComponent<Animator>();
    void Start()
    {
        gameObject.tag = "Player";
        currentHealth=maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        //Animation
        float velocityZ = Vector3.Dot(direction, transform.forward);
        float velocityX = Vector3.Dot(direction, transform.right);

        _animator.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
        _animator.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
        

    
       //Player facing mouse
       Plane playerPlane = new Plane(Vector3.up, transform.position);
       Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
       float hitDist = 0.0f;

       if(playerPlane.Raycast(ray, out hitDist))
       {
           Vector3 targetPoint= ray.GetPoint(hitDist);
           Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
           targetRotation.x = 0;
           targetRotation.z = 0;
           transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 7f * Time.deltaTime);
       }
       

        if(Input.GetButtonDown("Fire1")){
            Shoot();
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
    }

    void FixedUpdate()
    {

        if(currentHealth<= 0)
        {
            GameOver();
        }
        if(direction.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smooth);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                    controller.Move(moveDir.normalized * speed * Time.deltaTime);
                } 
    }

    void OnCollisionEnter(Collision collision)
    {
        EnemyBullet bullet = collision.gameObject.GetComponent<EnemyBullet>();
        if(bullet != null){
            currentHealth = currentHealth - 5;
            healthBar.SetHealth(currentHealth);
        }
    }

    void Heal()
    {
        Debug.Log("Heilen");
        if(currentHealth< maxHealth-10)
        {
            currentHealth = currentHealth + 10;
        }
        else
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
    void OnTriggerEnter(Collider other)
    {

        if(other.TryGetComponent<Healing>(out Healing heal))
        {
            Heal();
        }
        
        if(other.TryGetComponent<YellowKey>(out YellowKey yellow))
        {
            yellowKeyInstance = yellowKey;
            Debug.Log("YellowKey erhalten");
            Debug.Log(HasYellowKey());
        }

        if(other.TryGetComponent<BlueKey>(out BlueKey blue))
        {
            blueKeyInstance = blueKey;
            Debug.Log("BlueKey erhalten");
        }
        
    }

    public bool HasYellowKey()
    {
        if(yellowKeyInstance!=null)
        {
            return true;
        }
        else{
            return false;
        }
    }
    public bool HasBlueKey()
    {
        if(blueKeyInstance!=null)
        {
            return true;
        }
        else{
            return false;
        }
    }
public void GameOver()
    {
        Image.SetActive(true);
        StartCoroutine(LoadMenu());
    }
    IEnumerator LoadMenu()
    {

        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
