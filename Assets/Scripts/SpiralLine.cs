using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;
public class SpiralLine : MonoBehaviour
{
    public float length=10f;
    public VolumetricMultiLineBehavior line;
    public VolumetricMultiLineBehavior line2;
    public Vector3[] lineVertices;
    private float radius = 0.2f;
    private float intensityOfDot = 0.2f;
    private float density = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        lineVertices= new Vector3[(int)(length/intensityOfDot)+1];
        float deg = 0;
        int count =0;
        while(deg<length)
        {
            lineVertices[count].x=Mathf.Sin(deg)*radius;
            lineVertices[count].y=Mathf.Cos(deg)*radius;
            lineVertices[count].z=density*deg;
            deg=deg+intensityOfDot;
            count++;
        }
        line.UpdateLineVertices(lineVertices);
        line2.UpdateLineVertices(lineVertices);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }
}