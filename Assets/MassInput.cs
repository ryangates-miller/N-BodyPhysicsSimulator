using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MassInput : MonoBehaviour
{
    
    public TMP_InputField MaScale;
    public TMP_InputField PlanetName;
    public TMP_Text fText; 

    public float UniversEvolutionRate;
    public float UniversTimeStep;
    public float DistanceScale;
    public float Sizescale; 

    Body[] AllBodies;
    Solarsystem[] sol;
    // Start is called before the first frame update
    /*void Start()
    {
        TiScale = GameObject.Find("TiScale").GetComponent<InputField>();
    }*/

    void start(){
        //TiScale = GameObject.Find("TiScale").GetComponent<TMP_InputField>();
        PlanetName = GameObject.Find("PlanetName").GetComponent<TMP_InputField>();
        MaScale = GameObject.Find("MaScale").GetComponent<TMP_InputField>();
        //print("TimeIntervalIs:"+TiScale.text);
       

        AllBodies=FindObjectsOfType <Body> ();
        sol=FindObjectsOfType <Solarsystem> ();

        FindObjectsOfType <Solarsystem> ()[0].EvolutionTimeStep=UniversTimeStep;
        FindObjectsOfType <Solarsystem> ()[0].Size=Sizescale;


    }

//    void FixedUpdate(){
//
//
//    }
    // Update is called once per frame
    public void getvalue1(){
        //string time1 = TiScale.text;
        string Name1 = PlanetName.text;
        string mass1 = MaScale.text;
        //Debug.Log(time1);
        //TiScale.text = "";
        fText.text = "PlanetName: "+ Name1 + "\t" + "MassScale: " + mass1;
        AllBodies=FindObjectsOfType <Body> ();
        sol=FindObjectsOfType <Solarsystem> ();

        //FindObjectsOfType <Solarsystem> ()[0].EvolutionTimeStep=UniversTimeStep;
        //FindObjectsOfType <Solarsystem> ()[0].Size=Sizescale;
        float mass0;
        
        for(int i=0; i<AllBodies.Length; i++)
        {
            if(string.Equals(FindObjectsOfType <Body> ()[i].ToString(),(Name1+" (Body)")))
            {
                mass0=FindObjectsOfType <Body> ()[i].This_Body.mass;
                FindObjectsOfType <Body> ()[i].This_Body.mass=float.Parse(mass1)*mass0;
                break;
            }

            //FindObjectsOfType <Body> ()[i].timeStep=FindObjectsOfType <Solarsystem> ()[0].EvolutionTimeStep;
            //FindObjectsOfType <Body> ()[i].Body_radius=Sizescale*FindObjectsOfType <Body> ()[i].Body_radius/FindObjectsOfType <Solarsystem> ()[0].Size;
            //FindObjectsOfType <Body> ()[i].GetComponent<Transform> ().localScale=new Vector3 (FindObjectsOfType <Body> ()[i].Body_radius,FindObjectsOfType <Body> ()[i].Body_radius,FindObjectsOfType <Body> ()[i].Body_radius);
        }
    }
    /*public void getvalue2(){
        string Mass1 = MaScale.text;
        Debug.Log(Mass1);
        print("MassScaleIs:"+MaScale.text);
        MaScale.text = "";
        //print("MassScaleIs:"+MaScale.text);
    }*/
}
