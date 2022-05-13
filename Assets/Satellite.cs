using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody))]
public class Satellite : MonoBehaviour
{
    public Vector3 CurrentPosition;
    
    public Vector3 ParentPlanetPosition;
    Rigidbody This_Body;
    Solarsystem[] sol;
    Body[] AllBodies;

    PlanetSystem ParentPlanet;

    SatelliteObit ThisObit;

    private Vector3 ObitAxis;
    private float ObitAngularSpeed;
//    private Vector3 CurrentReletivePosition;
    public float timeStep;
    void Awake () {
        sol = FindObjectsOfType <Solarsystem> ();
        ThisObit = FindObjectsOfType<SatelliteObit>()[0];
        //Body_acceleration = Vector3.zero;
        timeStep=sol[0].EvolutionTimeStep;
        Debug.Log(this.ToString()+" loaded");
        This_Body = GetComponent<Rigidbody> ();
        ParentPlanet=GetComponentInParent<PlanetSystem>();
    }

    void Start()
    {
        ObitAxis=new Vector3(0,0.25f,1f);
        ObitAngularSpeed=240f;
        CurrentPosition=sol[0].MoonPosition;
        This_Body.position= CurrentPosition;
        //GetComponent<Transform>().position=CurrentPosition;
        //CurrentReletivePosition= CurrentPosition-GetComponentInParent<Rigidbody>().position;
        //Debug.Log(this.ToString()+This_Body.position);
        //ThisTransform = GetComponent<Transform>();
        ThisObit.transform.position=sol[0].MoonPosition;//This_Body.position-ParentPlanetPosition;
        GetComponent<Transform> ().localScale = new Vector3(sol[0].MoonBodyRadious,sol[0].MoonBodyRadious,sol[0].MoonBodyRadious);
    }

    void FixedUpdate()
    {   
        //ThisObit.transform.position=This_Body.position-ParentPlanetPosition;
        ParentPlanetPosition=ParentPlanet.PlanetPosition;
        ThisObit.transform.RotateAround(/*ParentPlanetPosition*/Vector3.zero,ObitAxis,ObitAngularSpeed*timeStep);
        CurrentPosition=ParentPlanetPosition+ThisObit.transform.position;
        This_Body.position= CurrentPosition;
        //for (int Multiple_speed=0; Multiple_speed < sol[0].EvolutionRate; Multiple_speed++){
           
        //}
        //This_Body.MovePosition (CurrentPosition);


    }

    //void updateCurrentPosition(float timeStep)
    //{


    //}

}
