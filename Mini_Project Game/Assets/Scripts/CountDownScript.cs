using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CountDownScript : MonoBehaviour
{
    [SerializeField]
    int time = 180;
    [SerializeField]
    Text txtLeftTime; 
    // Start is called before the first frame update
    void Start()
    {
        txtLeftTime.text = "Time Left: " + time;
        StartCoroutine(Pause());
    }

   IEnumerator Pause()
    {
        while (time > 0) {
            yield return new WaitForSeconds(1f);
            time--;
            txtLeftTime.text = "Time Left : " + time;
        }
        SceneManager.LoadScene("Menu");
    }
}
