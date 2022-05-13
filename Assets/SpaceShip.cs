using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    void Start()
    {
        GetComponentInChildren<TrailRenderer>().time=1f;
        GetComponentInChildren<TrailRenderer>().startWidth=5f;
        GetComponentInChildren<TrailRenderer>().startColor=Color.blue;
        GetComponentInChildren<TrailRenderer>().endColor=Color.red;
    }

    
}
