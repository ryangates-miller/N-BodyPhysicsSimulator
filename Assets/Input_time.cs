using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Input_time : MonoBehaviour
{
    public InputField Timmer;
    // Start is called before the first frame update
    //void Start()
   // {
        //transform.GetComponent<InputField>().onValueChanged.AddListener (Changed_Value);
        //transform.GetComponent<InputField>().onEndEdit.AddListener (End_Value);
        //Timmer = GameObject.Find("Timmer").GetComponent<InputField>();
    //}

    public void End_Value(){
        Timmer = GameObject.Find("Timmer").GetComponent<InputField>();
        print("IsTyping:"+Timmer.text);
    }
    /*public void  Changed_Value(string inp){
        Debug.Log("IsTyping:"+inp);
    }

    public void  End_Value(string inp){
        Debug.Log("Time:"+inp);
    }*/
    // Update is called once per frame
}
