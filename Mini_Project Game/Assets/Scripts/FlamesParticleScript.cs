using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlamesParticleScript : MonoBehaviour { 
  /*  [SerializeField] 
    int x;
    [SerializeField]
 bool autoGenerate;

  //  private void Start()
   // {
        if (autoGenerate)
        {
             x = SceneManager.GetActiveScene().buildIndex + 1;
        }
    }*/

private void OnCollisionEnter(Collision collision)
    {
       
        if(collision.collider.tag=="Player"){
            PlayerPrefs.SetInt("nächste Level 2", SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }
}
