using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comets : MonoBehaviour
{
    public int NumberOfComet=2;
    GameObject[] CometSet;
    GameObject Trail0;
    public GameObject ParentObject;
    public CometBody ThisComet;
    public Rigidbody ThisRigid;
    public TrailRenderer ThisTrail;
    public Trailsetting ThisTrailSetting;
    public Material ThisMaterial;
    public DefaultMaterial ThisDefaultMaterial;
    void Awake()
    {
        ThisDefaultMaterial=FindObjectsOfType <DefaultMaterial> ()[0];
        CometSet=new GameObject[NumberOfComet];
        //Trail0 = new GameObject[NumberOfComet];
        ParentObject=GameObject.Find("Comets");
        for (int i=0;i <NumberOfComet; i++)
        {
            
            CometSet[i]=GameObject.CreatePrimitive(PrimitiveType.Sphere); 
            CometSet[i].name= ("Comet "+(i+1));
            //Rigidbody CometSet[i] = gameObject.AddComponent(typeof(Rigidbody)) as Rigidbody;
            //CometSet[i].AddComponent<CometBody>();
            //CometSet[i].AddComponent<TrailRenderer>();
            CometSet[i].transform.parent=ParentObject.transform;
            ///Renderer rend=CometSet[i].GetComponent<Renderer>();
            //rend.material=new Material(Shader.Find("Earth"));
            //CometSet[i].GetComponent<MeshRenderer>().material.mainTexture=(Texture)(Resources.Load("Textures/jupitermap"));
            CometSet[i].GetComponent<MeshRenderer>().material=Resources.Load<Material>("Materials/CometMaterials/Mat"+(int)(Random.value*4));
            //Debug.Log(Resources.Load<Material>("Materials/CometMaterials/Mat"+(int)(Random.value*4)));
            //Assets/Resources/Materials/CometMaterials/Mat1.mat
            Trail0=new GameObject();
            Trail0.name=("Trail");
            Trail0.transform.parent=CometSet[i].transform;
            
            ThisTrail=Trail0.AddComponent<TrailRenderer>();
            ThisTrailSetting=Trail0.AddComponent<Trailsetting>();
            //ThisTrail.material=Resources.Load<Material>("Resources/unity_builtin_extra/Default-Line");//Resources/unity_builtin_extra
            //Debug.Log(Resources.Load<Material>("Resources/unity_builtin_extra/Default-Line"));
            ThisTrail.material=ThisDefaultMaterial.DefaultLine;
            ThisTrail.startWidth=10f;
            ThisTrail.endWidth=1f;
            ThisTrail.time=50f;//100f
            ThisTrail.startColor=new Color(Random.value,Random.value,Random.value);
            ThisTrail.endColor=Color.white;
        }
    }
    void Start()
    {
        for (int i=0;i <NumberOfComet; i++)
        {
            ThisRigid=CometSet[i].AddComponent<Rigidbody>();
            ThisComet=CometSet[i].AddComponent<CometBody>();
                        //ThisTrail.Clear();
        }
    }
}
