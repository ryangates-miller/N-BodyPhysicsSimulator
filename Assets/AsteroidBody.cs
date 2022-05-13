using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody))]
public class AsteroidBody : MonoBehaviour
{
    public float SizeScale { get; private set; }
    public Vector3 position { get; private set; }
    public Vector3 velocity { get; private set; }
    public Vector3 acceleration { get; private set; }
    public float timeStep { get; private set; }
    public Vector3 EularVelocity { get; private set; }
    Rigidbody This_Body;
    
    Body[] AllBodies;
    Solarsystem sol;

    void Awake()
    {
        This_Body=GetComponent<Rigidbody> ();
        AllBodies = FindObjectsOfType <Body> ();
        sol = FindObjectsOfType <Solarsystem> ()[0];
        acceleration = Vector3.zero;
        timeStep=sol.EvolutionTimeStep;
        This_Body.useGravity=false;
              
    }
    void Start()
    {
        float CenterOrbitRadious;
        float OrbitWidth;
        float ThisOrbitRadious;
        CenterOrbitRadious=(sol.JupiterOrbitRadious+sol.MarsOrbitRadious)/2f;
        OrbitWidth=(sol.JupiterOrbitRadious-sol.MarsOrbitRadious)/3f;
        //float signal=Random.value;
        if(Random.value>0.5f)
        {
            ThisOrbitRadious=((float)System.Math.Sin(Random.value*3.14f/2f)-1f)*OrbitWidth*0.5f+CenterOrbitRadious;
        }
        else
        {
            ThisOrbitRadious=((float)System.Math.Sin(Random.value*3.14f/2f)-1f)*OrbitWidth*-0.5f+CenterOrbitRadious;
        }
        position=sol.GeneratePosition0(ThisOrbitRadious);
        velocity=sol.CaculateVelocity0(ThisOrbitRadious,position,new Vector3(0,0.2f*Random.value,1).normalized,sol.SunMass);
        This_Body.position=position;

        GetComponent<Transform> ().localScale = new Vector3 (sol.MecuryBodyRadious*Random.value*0.5f,sol.MecuryBodyRadious*Random.value*0.66f,sol.MecuryBodyRadious*Random.value*0.66f);
        EularVelocity = (new Vector3(Random.value,Random.value,Random.value).normalized)*200f*Random.value;
    }
    void FixedUpdate()
    {
        acceleration=Vector3.zero;
        Body[] AllBodies1=AllBodies;
        foreach (var otherBody in AllBodies1) 
        {
            float SqrDistance = (otherBody.CurrentPosition - This_Body.position).sqrMagnitude;
            Vector3 ForceDirection = (otherBody.CurrentPosition - This_Body.position).normalized;
            acceleration += ForceDirection * sol.GravityConstant * otherBody.CurrentMass / SqrDistance;
        }
        velocity=velocity+acceleration*timeStep;
        position+=velocity*timeStep;
        This_Body.MovePosition (position);

        Quaternion deltaRotation = Quaternion.Euler(EularVelocity*timeStep);
        This_Body.MoveRotation(This_Body.rotation*deltaRotation);
    }
}
