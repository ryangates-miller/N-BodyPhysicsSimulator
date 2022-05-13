using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
public int NumberOfAsteroid=2;
    GameObject[] AsteroidSet;
    GameObject Trail0;
    public GameObject ParentObject;
    public AsteroidBody ThisAsteroid;
    public Rigidbody ThisRigid;
    public TrailRenderer ThisTrail;
    public Trailsetting ThisTrailSetting;
    public Material ThisMaterial;
    public DefaultMaterial ThisDefaultMaterial;
    void Awake()
    {
        ThisDefaultMaterial=FindObjectsOfType <DefaultMaterial> ()[0];
        AsteroidSet=new GameObject[NumberOfAsteroid];
        //Trail0 = new GameObject[NumberOfAsteroid];
        ParentObject=GameObject.Find("Asteroids");
        for (int i=0;i <NumberOfAsteroid; i++)
        {
            
            AsteroidSet[i]=GameObject.CreatePrimitive(PrimitiveType.Sphere); 
            AsteroidSet[i].name= ("Asteroid "+(i+1));
            //Rigidbody AsteroidSet[i] = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            //AsteroidSet[i].AddComponent<AsteroidBody>();
            //AsteroidSet[i].AddComponent<TrailRenderer>();
            AsteroidSet[i].transform.parent=ParentObject.transform;
            ///Renderer rend=AsteroidSet[i].GetComponent<Renderer>();
            //rend.material=new Material(Shader.Find("Earth"));
            //AsteroidSet[i].GetComponent<MeshRenderer>().material.mainTexture=(Texture)(Resources.Load("Textures/jupitermap"));
            AsteroidSet[i].GetComponent<MeshRenderer>().material=Resources.Load<Material>("Materials/AsteroidMaterials/Mat"+(int)(Random.value*4));
            //Debug.Log(Resources.Load<Material>("Materials/AsteroidMaterials/Mat"+(int)(Random.value*4)));
            //Assets/Resources/Materials/AsteroidMaterials/Mat1.mat
            Trail0=new GameObject();
            Trail0.name=("Trail");
            Trail0.transform.parent=AsteroidSet[i].transform;
            
            ThisTrail=Trail0.AddComponent<TrailRenderer>();
            ThisTrailSetting=Trail0.AddComponent<Trailsetting>();
            //ThisTrail.material=Resources.Load<Material>("Resources/unity_builtin_extra/Default-Line");//Resources/unity_builtin_extra
            //Debug.Log(Resources.Load<Material>("Resources/unity_builtin_extra/Default-Line"));
            ThisTrail.material=ThisDefaultMaterial.DefaultLine;
            ThisTrail.startWidth=5f;
            ThisTrail.endWidth=1f;
            ThisTrail.time=0.1f;
            ThisTrail.startColor=new Color(Random.value,Random.value,Random.value);
            ThisTrail.endColor=Color.white;
        }
    }
    void Start()
    {
        for (int i=0;i <NumberOfAsteroid; i++)
        {
            ThisRigid=AsteroidSet[i].AddComponent<Rigidbody>();
            ThisAsteroid=AsteroidSet[i].AddComponent<AsteroidBody>();
                        //ThisTrail.Clear();
        }
    }

}
