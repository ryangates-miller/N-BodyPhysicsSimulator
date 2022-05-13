using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Out : MonoBehaviour
{
    public void Click() 
    {
       #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
    /*private void start(){
        this.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnClick(){
        
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }*/
}
