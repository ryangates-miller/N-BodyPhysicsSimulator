using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultMaterial : MonoBehaviour
{
    // Start is called before the first frame update
    public Material DefaultLine;
    public Material DefaultMesh;
    void Awake()
    {
        DefaultLine=GetComponent<LineRenderer>().material;
        DefaultMesh=GetComponent<MeshRenderer>().material;
    }

}
