using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
    public Color ThisColor; 
    public int lengthOfLineRenderer = 1000;
    public Vector3 ThisPosition; 
    PlanetSystem ParentPlanet;
    private float RingRadiousScale;
    void Awake()
    {
        ThisColor=new Color(Random.value,Random.value,Random.value);
        ParentPlanet=GetComponentInParent<PlanetSystem>();
        RingRadiousScale=200f+200f*Random.value;

    }
    void Start()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 10f;
        
        lineRenderer.positionCount = lengthOfLineRenderer;
        lineRenderer.startColor = ThisColor;
        lineRenderer.endColor = ThisColor;
        ThisPosition=ParentPlanet.PlanetPosition;
        lineRenderer.loop=true;
    }

    void Update()
    {
        ThisPosition=ParentPlanet.PlanetPosition;
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        var points = new Vector3[lengthOfLineRenderer];
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            points[i] = new Vector3(Mathf.Cos((float)i/(float)lengthOfLineRenderer * 3.1415f*2f), Mathf.Sin((float)i/(float)lengthOfLineRenderer * 3.1415f*2f), 0.5f*Mathf.Sin((float)i/(float)lengthOfLineRenderer * 3.1415f*2f)).normalized*RingRadiousScale+ThisPosition;
        }
        lineRenderer.SetPositions(points);
    }
}

