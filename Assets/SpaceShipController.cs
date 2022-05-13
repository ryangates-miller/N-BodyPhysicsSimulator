using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody))]
public class SpaceShipController : MonoBehaviour
{
    public Vector3 InitialPosition;
    public Vector3 position { get; private set; }
    public Vector3 velocity;
    public Vector3 acceleration { get; private set; }
    public Vector3 RocketAcceleration;
    public float timeStep { get; private set; }
    public Vector3 VelocitDirecrion;
    public Vector3 AccelerationDirecrion;
//    public Vector3 EularVelocity { get; private set; }
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
        InitialPosition=new Vector3(0,2000f,2000f);
    }
    void Start()
    {        
        position=InitialPosition;
        velocity=sol.CaculateVelocity0(position.magnitude,position,new Vector3(0,0.6f*Random.value,1).normalized,sol.SunMass)*1f;
        //Debug.Log(velocity);
        //position=sol.GeneratePosition0(ThisOrbitRadious);
        This_Body.position=position;
        //GetComponent<Transform> ().localScale = new Vector3 (sol.MecuryBodyRadious*Random.value*0.66f,sol.MecuryBodyRadious*Random.value*0.66f,sol.MecuryBodyRadious*Random.value*0.66f);
        //EularVelocity = (new Vector3(Random.value,Random.value,Random.value).normalized)*200f*Random.value;
        RocketAcceleration=Vector3.zero;
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
        acceleration += RocketAcceleration;
        velocity=velocity+acceleration*timeStep;
        position+=velocity*timeStep;
        This_Body.MovePosition (position);

        VelocitDirecrion=velocity.normalized;
        //Quaternion deltaRotation = Quaternion.Euler(EularVelocity*timeStep);
        //This_Body.MoveRotation(This_Body.rotation*deltaRotation);
    }

    void Update()
    {
        AccelerationDirecrion=VelocitDirecrion;
        RocketAcceleration=Vector3.zero;
        if (Input.GetKey(KeyCode.RightAlt))
        {
            AccelerationDirecrion=GameObject.Find("Main Camera").transform.forward;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            RocketAcceleration=AccelerationDirecrion*100f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            RocketAcceleration=AccelerationDirecrion*-100f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            AccelerationDirecrion=GameObject.Find("Main Camera").transform.right;
            RocketAcceleration=AccelerationDirecrion*-100f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            AccelerationDirecrion=GameObject.Find("Main Camera").transform.right;
            RocketAcceleration=AccelerationDirecrion*100f;
        }


    }
}