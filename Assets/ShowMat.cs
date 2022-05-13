using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Material Mat1=GetComponent<TrailRenderer>().material;
        Debug.Log(Mat1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
