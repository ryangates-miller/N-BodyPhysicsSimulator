using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameralRT : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2.5f;
    public Vector3 lookat;

    void Start()
    {
//        Debug.Log(GetComponent<Transform> ().Rotation);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * -x * speed, Space.World);
        float y = Input.GetAxis("Mouse Y");
        //绕自身的x轴转
        transform.Rotate(Vector3.right * -y * speed);
  //      lookat= GetComponent<Transform> ().localRotation;
    }
    
}
