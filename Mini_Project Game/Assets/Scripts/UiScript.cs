using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiScript : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(1);
    }
    public void ExitGame() {
  #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying=false;
   #else

        Application.Quit();
   #endif
    }

    public void ContinueGame()
    {
        int x;
        x = PlayerPrefs.GetInt("nächste Level 2");
        if (x > 1)
        {
            SceneManager.LoadScene(2);
        }
        else { SceneManager.LoadScene(1); }
        
    }
   
}
