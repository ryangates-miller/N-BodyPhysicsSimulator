using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameralMV : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject gameObject;
	float x1;
	float x2;
	float x3;
	float x4;
    void Start()
    {
        gameObject = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
		{
			transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
		}

		//w键前进
		if (Input.GetKey(KeyCode.W))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, 500f * Time.deltaTime));
		}
		//s键后退
		if (Input.GetKey(KeyCode.S))
		{
			this.gameObject.transform.Translate(new Vector3(0, 0, -500f * Time.deltaTime));
		}
		//a键后退
		if (Input.GetKey(KeyCode.A))
		{
			this.gameObject.transform.Translate(new Vector3(-50f, 0, 0 * Time.deltaTime));
		}
		//d键后退
		if (Input.GetKey(KeyCode.D))
		{
			this.gameObject.transform.Translate(new Vector3(50f, 0, 0 * Time.deltaTime));
		}
    }
}
