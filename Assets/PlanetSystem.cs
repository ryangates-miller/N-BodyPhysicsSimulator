using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSystem : MonoBehaviour
{
    public Vector3 PlanetPosition;
    Body[] AllBodies;

    Body ThisPlanet;

    // Start is called before the first frame update
    void Start()
    {
        AllBodies=FindObjectsOfType <Body> ();
        switch(this.ToString())
        {
            case "Earth (PlanetSystem)":
            {
                for(int i=0; i<AllBodies.Length; i++)
                {
                    if (AllBodies[i].ToString() == "Earth (Body)")
                    {
                        ThisPlanet=AllBodies[i];
                        break;
                    }
                }
                PlanetPosition=ThisPlanet.CurrentPosition;
                break;

            }
            case "Saturn (PlanetSystem)":
            {
                for(int i=0; i<AllBodies.Length; i++)
                {
                    if (AllBodies[i].ToString() == "Saturn (Body)")
                    {
                        ThisPlanet=AllBodies[i];
                        break;
                    }
                }
                PlanetPosition=ThisPlanet.CurrentPosition;
                break;

            }
            case "Jupiter (PlanetSystem)":
            {
                for(int i=0; i<AllBodies.Length; i++)
                {
                    if (AllBodies[i].ToString() == "Jupiter (Body)")
                    {
                        ThisPlanet=AllBodies[i];
                        break;
                    }
                }
                PlanetPosition=ThisPlanet.CurrentPosition;
                break;

            }
            case "Uranus (PlanetSystem)":
            {
                for(int i=0; i<AllBodies.Length; i++)
                {
                    if (AllBodies[i].ToString() == "Uranus (Body)")
                    {
                        ThisPlanet=AllBodies[i];
                        break;
                    }
                }
                PlanetPosition=ThisPlanet.CurrentPosition;
                break;

            }
            case "Neptune (PlanetSystem)":
            {
                for(int i=0; i<AllBodies.Length; i++)
                {
                    if (AllBodies[i].ToString() == "Neptune (Body)")
                    {
                        ThisPlanet=AllBodies[i];
                        break;
                    }
                }
                PlanetPosition=ThisPlanet.CurrentPosition;
                break;

            }
            default: 
                break;   
        }
    }

    void FixedUpdate()
    {
        PlanetPosition=ThisPlanet.CurrentPosition;
    }

}
