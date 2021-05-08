using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CountDownScript : MonoBehaviour
{
    [SerializeField]
    int time = 180;
    [SerializeField]
    Text txtTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        txtTimeLeft.text = "Time Left: " + time;
        StartCoroutine(Pause());   
    }
    IEnumerator Pause() { 
    while (time > 0)
        {
            
            yield return new WaitForSeconds(1f);
            time--;
            txtTimeLeft.text = "Time Left: " + time;
        }
        GameObject.Find("Player").GetComponent<Movement>().GameOver();
    }
    
  
}
