using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlamesParticleScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag=="Player"){
            PlayerPrefs.SetInt("nächste Level 2", 2);
            SceneManager.LoadScene(2);

        }
    }
}
