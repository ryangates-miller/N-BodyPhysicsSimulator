using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLocationController : MonoBehaviour
{
    private GameObject Camera;
    private int isGod;
    private GameObject FollowingTarget;
    public Vector3 CameraPosition;
    private Quaternion ThisRotation;
    void Awake()
    {
        Camera = GameObject.Find("Main Camera");
        FollowingTarget=GameObject.Find("Godview");
        CameraPosition=Vector3.zero;
    }
    void Start()
    {
        //Camera.transform.parent=God.transform;
        CameraPosition=FollowingTarget.transform.position;
        Camera.transform.position=CameraPosition;
        ThisRotation=Camera.transform.rotation;
        isGod=1;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
		{
            FollowingTarget=GameObject.Find("Godview");
            CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=1;
		}
        if (Input.GetKey(KeyCode.Alpha1))
		{
            FollowingTarget=GameObject.Find("Mecury");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
		}
        if (Input.GetKey(KeyCode.Alpha2))
		{
            FollowingTarget=GameObject.Find("Venus");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
		}
        if (Input.GetKey(KeyCode.Alpha3))
		{
            FollowingTarget=GameObject.Find("Earth");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha4))
		{
            FollowingTarget=GameObject.Find("Mars");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha5))
		{
            FollowingTarget=GameObject.Find("Jupiter");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha6))
		{
            FollowingTarget=GameObject.Find("Saturn");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha7))
		{
            FollowingTarget=GameObject.Find("Uranus");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha8))
		{
            FollowingTarget=GameObject.Find("Neptune");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=0;
        }
        if (Input.GetKey(KeyCode.Alpha9))
		{
            FollowingTarget=GameObject.Find("SpaceShip");
			CameraPosition=FollowingTarget.transform.position;
            CameraPosition=CameraPosition+((new Vector3(0,0,2f)+FindObjectsOfType <SpaceShipController> ()[0]/*GameObject.Find("SpaceShipController").SpaceShipController*/.VelocitDirecrion.normalized*-2f)*FollowingTarget.transform.localScale.z);
            Camera.transform.position=CameraPosition;
            Camera.transform.rotation=ThisRotation;
            Camera.transform.localScale=new Vector3(1,1,1);
            isGod=2;
        }
        if(isGod!=1)
            if(isGod==2)
            {
                Camera.transform.position=FollowingTarget.transform.position+((new Vector3(0,0,2f)+FindObjectsOfType <SpaceShipController> ()[0]/*GameObject.Find("SpaceShipController").SpaceShipController*/.VelocitDirecrion.normalized*-2f)*FollowingTarget.transform.localScale.z);
            }
            else
                Camera.transform.position=FollowingTarget.transform.position+(new Vector3(0,0,2f)*FollowingTarget.transform.localScale.z);
    
    }
}
