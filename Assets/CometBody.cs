using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody))]
public class CometBody : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        float ThisOrbitRadious;
        ThisOrbitRadious=sol.NeptuneOrbitRadious*(1f+0.001f*Random.value);
        Vector3 positiondirection = new Vector3(Random.value*2-1f, Random.value*2-1f, Random.value*0.5f-0.5f);
        position=positiondirection.normalized*ThisOrbitRadious;
        velocity=sol.CaculateVelocity0(ThisOrbitRadious,position,new Vector3(0,0.6f*Random.value,1).normalized,sol.SunMass)*0.5f*Random.value;
        //Debug.Log(velocity);
        //position=sol.GeneratePosition0(ThisOrbitRadious);
        This_Body.position=position;
        GetComponent<Transform> ().localScale = new Vector3 (sol.MecuryBodyRadious*Random.value*0.66f,sol.MecuryBodyRadious*Random.value*0.66f,sol.MecuryBodyRadious*Random.value*0.66f);
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
