using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solarsystem : MonoBehaviour
{
    //Univers Constant
    public float GravityConstant=1000f;
    public int EvolutionRate=10;
    public float EvolutionTimeStep=0.02f;
    public float AU=1000f;
    public float Size=1f;

    // Mass for all Bodies
    public float SunMass;
    public float MecuryMass;
    public float VenusMass;
    public float EarthMass;
    public float MarsMass;
    public float JupiterMass;
    public float SaturnMass;
    public float UranusMass;
    public float NeptuneMass;

    // Body Radious for all Bodies
    public float SunBodyRadious;
    public float MecuryBodyRadious;
    public float VenusBodyRadious;
    public float EarthBodyRadious;
    public float MarsBodyRadious;
    public float JupiterBodyRadious;
    public float SaturnBodyRadious;
    public float UranusBodyRadious;
    public float NeptuneBodyRadious;

    // Orbit Radious for all Planets
    //    public float SunObRadious;
    public float MecuryOrbitRadious;
    public float VenusOrbitRadious;
    public float EarthOrbitRadious;
    public float MarsOrbitRadious;
    public float JupiterOrbitRadious;
    public float SaturnOrbitRadious;
    public float UranusOrbitRadious;
    public float NeptuneOrbitRadious;

    //Self rotation
    public Vector3 SunSelfRotation;
    public Vector3 MecurySelfRotation;
    public Vector3 VenusSelfRotation;
    public Vector3 EarthSelfRotation;
    public Vector3 MarsSelfRotation;
    public Vector3 JupiterSelfRotation;
    public Vector3 SaturnSelfRotation;
    public Vector3 UranusSelfRotation;
    public Vector3 NeptuneSelfRotation;

    // Position for all Bodies
    public Vector3 SunPosition { get; private set; }
    public Vector3 MecuryPosition { get; private set; }
    public Vector3 EarthPosition { get; private set; }
    public Vector3 MarsPosition { get; private set; }
    public Vector3 JupiterPosition { get; private set; }
    public Vector3 SaturnPosition { get; private set; }
    public Vector3 UranusPosition { get; private set; }
    public Vector3 VenusPosition { get; private set; }
    public Vector3 NeptunePosition { get; private set; }
    // Velosity for all Bodies
    public Vector3 SunVelocity { get; private set; }
    public Vector3 MecuryVelocity { get; private set; }
    public Vector3 VenusVelocity { get; private set; }
    public Vector3 EarthVelocity { get; private set; }
    public Vector3 JupiterVelocity { get; private set; }
    public Vector3 SaturnVelocity { get; private set; }
    public Vector3 MarsVelocity { get; private set; }
    public Vector3 UranusVelocity { get; private set; }
    public Vector3 NeptuneVelocity { get; private set; }

    //satellites
    public float MoonMass;
    public float MoonBodyRadious;
    public float MoonOrbitRadious;
    public Vector3 MoonPosition { get; private set; }
    public Vector3 MoonVelocity { get; private set; }

    void Awake()
    {
        Vector3 orbitdirection0=new Vector3(0,0,1);
        //Univers
        GravityConstant=1000f;
        EvolutionRate=1;
        EvolutionTimeStep=0.02f;
        AU=1000f;
        Size=10f;

        //Sun
        SunMass=330000f;
        SunPosition=new Vector3(0,0,0);
        SunVelocity=new Vector3(0,0,0);
        SunBodyRadious=50*Size;
        SunSelfRotation=Vector3.forward*3000f/25f;

        //Mecury
        MecuryMass=0.05527f;
        MecuryOrbitRadious=0.38709f*AU;
        MecuryPosition=GeneratePosition0(MecuryOrbitRadious);
        orbitdirection0=new Vector3(0,0.121f*3,0.992f);
        MecuryVelocity=CaculateVelocity0(MecuryOrbitRadious,MecuryPosition,orbitdirection0.normalized,SunMass);
        MecuryBodyRadious=5*Size;
        MecurySelfRotation=Vector3.forward*3000f/58f;
        //Venus
        VenusMass=0.815f;
        VenusOrbitRadious=0.72332f*AU;
        VenusPosition=GeneratePosition0(VenusOrbitRadious);
        orbitdirection0=new Vector3(0,0.06f*3,0.998f);
        VenusVelocity=CaculateVelocity0(VenusOrbitRadious,VenusPosition,orbitdirection0.normalized,SunMass);
        VenusBodyRadious=10*Size;
        VenusSelfRotation=new Vector3(0f,0.05f,-0.998f).normalized*3000f/243f;
        //Earth
        EarthMass=1f;
        EarthOrbitRadious=1f*AU;
        EarthPosition=GeneratePosition0(EarthOrbitRadious);
        orbitdirection0=new Vector3(0,0,1f);
        EarthVelocity=CaculateVelocity0(EarthOrbitRadious,EarthPosition,orbitdirection0.normalized,SunMass);
        EarthBodyRadious=10*Size;
        EarthSelfRotation=new Vector3(0f,0.39f,0.917f).normalized*3000f/1f;
        //Mars
        MarsMass=0.10745f;
        MarsOrbitRadious=1.52366f*AU;
        MarsPosition=GeneratePosition0(MarsOrbitRadious);
        orbitdirection0=new Vector3(0,0.032f*3,1f);
        MarsVelocity=CaculateVelocity0(MarsOrbitRadious,MarsPosition,orbitdirection0.normalized,SunMass);
        MarsBodyRadious=7*Size;
        MarsSelfRotation=new Vector3(0f,0.42f,0.906f).normalized*3000f/1;
        //Jupiter
        JupiterMass=317.816f;
        JupiterOrbitRadious=5.20336f*AU;
        //JupiterOrbitRadious=2.20336f*AU;
        JupiterPosition=GeneratePosition0(JupiterOrbitRadious);
        orbitdirection0=new Vector3(0,0.03f*3,1f);
        JupiterVelocity=CaculateVelocity0(JupiterOrbitRadious,JupiterPosition,orbitdirection0.normalized,SunMass);
        JupiterBodyRadious=40*Size;
        JupiterSelfRotation=new Vector3(0f,0.01f,1f).normalized*3000f/0.41f;
        //Saturn
        SaturnMass=95.1609f;
        SaturnOrbitRadious=9.53707f*AU;
        //SaturnOrbitRadious=3.53707f*AU;
        SaturnPosition=GeneratePosition0(SaturnOrbitRadious);
        orbitdirection0=new Vector3(0,0.043f*3,1f);
        SaturnVelocity=CaculateVelocity0(SaturnOrbitRadious,SaturnPosition,orbitdirection0.normalized,SunMass);
        SaturnBodyRadious=35*Size;
        SaturnSelfRotation=new Vector3(0f,0.43f,0.9f).normalized*3000f/0.44f;
        //Uranus
        UranusMass=14.5373f;
        UranusOrbitRadious=19.19126f*AU;
        //UranusOrbitRadious=5.19126f*AU;
        UranusPosition=GeneratePosition0(UranusOrbitRadious);
        orbitdirection0=new Vector3(0,0.013f*3,1f);
        UranusVelocity=CaculateVelocity0(UranusOrbitRadious,UranusPosition,orbitdirection0.normalized,SunMass);
        UranusBodyRadious=20*Size;
        UranusSelfRotation=new Vector3(0f,0.99f,-0.12f).normalized*3000f/0.71f;
        //Neptune
        NeptuneMass=17.1471f;
        NeptuneOrbitRadious=30.06869f*AU;
        //NeptuneOrbitRadious=7.06869f*AU;
        NeptunePosition=GeneratePosition0(NeptuneOrbitRadious);
        orbitdirection0=new Vector3(0,0.03f*3,1f);
        NeptuneVelocity=CaculateVelocity0(NeptuneOrbitRadious,NeptunePosition,orbitdirection0.normalized,SunMass);
        NeptuneBodyRadious=25*Size;
        NeptuneSelfRotation=new Vector3(0f,0.48f,0.87f).normalized*3000f/0.66f;

        //Moon
        MoonMass=0.0123f;
        MoonMass=1f;
        MoonOrbitRadious=0.08f*AU;
        MoonPosition=GeneratePosition0(MoonOrbitRadious);
        MoonVelocity=EarthVelocity+CaculateVelocity0(MoonOrbitRadious,EarthPosition-MoonPosition,orbitdirection0,EarthMass);
        MoonBodyRadious=5*Size;

    }
    public Vector3 GeneratePosition0(float OrbitRadious){
        Vector3 positiondirection = new Vector3(Random.value*2-1f, Random.value*2-1f, 0f);
        return positiondirection.normalized*OrbitRadious;
    }
    public Vector3 CaculateVelocity0(float OrbitRadious, Vector3 position, Vector3 orbitdirection, float CenturalMass){
        Vector3 velocitydirection = Vector3.Cross(orbitdirection,position).normalized;
        return velocitydirection*(float)System.Math.Sqrt(GravityConstant*CenturalMass/OrbitRadious);
    }

}
