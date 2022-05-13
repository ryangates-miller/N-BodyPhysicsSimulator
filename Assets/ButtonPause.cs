using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour{
  //the ButtonPauseMenu
    public GameObject ingameMenu;
    public void OnPause(){
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }
    public void OnResume(){
        Time.timeScale = 1f;
        ingameMenu.SetActive(false);
    }
    public void OnRestart(){
        //Loading Scene0
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        //foreach (var oneTrail in FindObjectsOfType <Trailsetting> ())
        //{
        //    oneTrail.Reset();
        //}      
    }
    public void OnQuit(){
        //Loading Scene0
       #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}