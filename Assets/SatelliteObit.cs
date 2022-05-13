using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteObit : MonoBehaviour
{
    public Transform ObitTransform;
    // Start is called before the first frame update
    void Awake()
    {
        ObitTransform=GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
