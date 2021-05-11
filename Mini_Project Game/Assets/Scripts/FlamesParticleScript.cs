using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlamesParticleScript : MonoBehaviour {
    [SerializeField]
    int x;
 
    private void Start()
  {
      
        
             x = SceneManager.GetActiveScene().buildIndex + 1;
        
    }

private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.collider.tag=="Player"){
            
            PlayerPrefs.SetInt("nächste Level 2", x);
            SceneManager.LoadScene(x);


        }
    }
}
