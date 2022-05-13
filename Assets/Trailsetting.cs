using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailsetting : MonoBehaviour
{

    public float LastingTime;
    public float TrailWidth;
    private int frameFlag;

    TrailRenderer Trail1;

    void Awake()
    {
    Trail1=GetComponent<TrailRenderer>();
    Trail1.time=4f;
    Trail1.startWidth=10f;
    Trail1.endWidth=1f;
//    Trail1.Clear;
    frameFlag=0;
    }
    // Start is called before the first frame update
    void Start()
    {
        Trail1.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        if(frameFlag<10){
            Trail1.Clear();
        }
        frameFlag++;     
    }
    public void Reset()
    {
        Trail1.Clear();
    }
}


