using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent (typeof (Rigidbody))]

public class Body : MonoBehaviour{

    public float Radius;
    public float Mass;
    public Vector3 initialVelocity;
    public Vector3 initialPosition;
    public float CurrentVelocity;
    public float CurrentMass;
    public Vector3 CurrentPosition;
    public Vector3 CurrentVelocityVector;
    public Vector3 CurrentAccelerationVector;

    public Vector3 Body_velocity { get; private set; }
    public Vector3 Body_position { get; private set; }
    public float Body_mass { get;  set; }
    public float Body_radius { get; set; }
    public Vector3 Body_acceleration { get; private set; }
    public Vector3 EularVelocity { get; private set; }
    public float timeStep;
    public Rigidbody This_Body;
    
    Body[] AllBodies;
    Solarsystem[] sol;

    void Awake () {
        sol = FindObjectsOfType <Solarsystem> ();
        Body_acceleration = Vector3.zero;
        timeStep=sol[0].EvolutionTimeStep;
        Debug.Log(this.ToString()+" loaded");  
    }

    void Start() {
        timeStep=sol[0].EvolutionTimeStep;
        switch(this.ToString()){
            case "Sun (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].SunMass;
                Body_position = sol[0].SunPosition;
                Body_velocity = sol[0].SunVelocity;
                Body_radius = sol[0].SunBodyRadious;
                EularVelocity=sol[0].SunSelfRotation;
                break;

            case "Mecury (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].MecuryMass;
                Body_position = sol[0].MecuryPosition;
                Body_velocity = sol[0].MecuryVelocity;
                Body_radius = sol[0].MecuryBodyRadious;
                EularVelocity=sol[0].MecurySelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].MecuryOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                //GetComponentInChildren<TrailRenderer> ().material.color
                break;

            case "Venus (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].VenusMass;
                Body_position = sol[0].VenusPosition;
                Body_velocity = sol[0].VenusVelocity;
                Body_radius = sol[0].VenusBodyRadious;
                EularVelocity=sol[0].VenusSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].VenusOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Earth (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].EarthMass;
                Body_position = sol[0].EarthPosition;
                Body_velocity = sol[0].EarthVelocity;
                Body_radius = sol[0].EarthBodyRadious;
                EularVelocity=sol[0].EarthSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].EarthOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Mars (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].MarsMass;
                Body_position = sol[0].MarsPosition;
                Body_velocity = sol[0].MarsVelocity;
                Body_radius = sol[0].MarsBodyRadious;
                EularVelocity=sol[0].MarsSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].MarsOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Jupiter (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].JupiterMass;
                Body_position = sol[0].JupiterPosition;
                Body_velocity = sol[0].JupiterVelocity;
                Body_radius = sol[0].JupiterBodyRadious;
                EularVelocity=sol[0].JupiterSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].JupiterOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Saturn (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].SaturnMass;
                Body_position = sol[0].SaturnPosition;
                Body_velocity = sol[0].SaturnVelocity;
                Body_radius = sol[0].SaturnBodyRadious;
                EularVelocity=sol[0].SaturnSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].SaturnOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Uranus (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].UranusMass;
                Body_position = sol[0].UranusPosition;
                Body_velocity = sol[0].UranusVelocity;
                Body_radius = sol[0].UranusBodyRadious;
                EularVelocity=sol[0].UranusSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].UranusOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Neptune (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].NeptuneMass;
                Body_position = sol[0].NeptunePosition;
                Body_velocity = sol[0].NeptuneVelocity;
                Body_radius = sol[0].NeptuneBodyRadious;
                EularVelocity=sol[0].NeptuneSelfRotation;
                GetComponentInChildren<TrailRenderer> ().time=sol[0].NeptuneOrbitRadious*3.14f*2f/Body_velocity.magnitude;
                break;

            case "Moon (Body)":
                Debug.Log(this+"matched");
                Body_mass = sol[0].MoonMass;
                Body_position = sol[0].MoonPosition;
                Body_velocity = sol[0].MoonVelocity;
                Body_radius = sol[0].MoonBodyRadious;
                break;

            default:
                Body_mass = Mass;
                Body_velocity = initialVelocity;
                Body_position = initialPosition;
                Body_radius = Radius;
                break;
        }
        Mass=Body_mass;
        initialVelocity=Body_velocity;
        initialPosition=Body_position;
        Radius=Body_radius;

        GetComponent<Transform> ().localScale = new Vector3 (Body_radius,Body_radius,Body_radius);
        //GetComponent<Transform> ().localPosition=Body_position;
        GetComponent<Rigidbody> ().position = Body_position;
        GetComponent<Rigidbody> ().mass = Body_mass;
        This_Body = GetComponent<Rigidbody> ();
        AllBodies = FindObjectsOfType <Body> ();
        This_Body.useGravity=false;
    //    Debug.Log("Number pf body"+AllBodies.Length);
    //    GetComponentInChildren<Trail> ()
    //    GetComponentInChildren<TrailRenderer> ().Clear;
    }

    void FixedUpdate(){
        for (int Multiple_speed=0; Multiple_speed < sol[0].EvolutionRate; Multiple_speed++){
        UpdateAcceleration (AllBodies,sol[0].GravityConstant);
        UpdateVelocity (timeStep);
        UpdatePosition (timeStep);
        UpdateRotation (timeStep);
        }
        This_Body.MovePosition (Body_position);
        //This_Body.MoveRotation ();
        CurrentMass=This_Body.mass;
        CurrentPosition=Body_position;
        CurrentVelocity=Body_velocity.sqrMagnitude;
        CurrentVelocityVector=Body_velocity;
        CurrentAccelerationVector=Body_acceleration;
    }

    public void UpdateAcceleration (Body[] allBodies,float GravityConstant) {
        Body_acceleration=Vector3.zero;
        foreach (var otherBody in allBodies) {
            if (otherBody != this) {
//                Body_acceleration=Vector3.zero;
                float SqrDistance = (otherBody.This_Body.position - This_Body.position).sqrMagnitude;
                Vector3 ForceDirection = (otherBody.This_Body.position - This_Body.position).normalized;
                Body_acceleration += ForceDirection * GravityConstant * otherBody.This_Body.mass / SqrDistance;
            }
//            Body_acceleration=(Vector3.zero - This_Body.position).normalized*1f;
//            Body_acceleration=Vector3.zero;
        }
    }

    public void UpdateVelocity (float timeStep) {
        Body_velocity += Body_acceleration * timeStep;
//        This_Body.velocity=Body_velocity;
    }

    public void UpdatePosition (float timeStep) {
        Body_position = Body_position + Body_velocity * timeStep;

    }

     public void UpdateRotation (float timeStep) {
        //Vector3 EularVelocity = Vector3.forward*100f;

        Quaternion deltaRotation = Quaternion.Euler(EularVelocity*timeStep);
        This_Body.MoveRotation(This_Body.rotation*deltaRotation);
        //= This_Body.rotation + Vector3.up * timeStep;

    }

}