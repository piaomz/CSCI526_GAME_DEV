using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VolumetricLines;


public class SpiralLine : MonoBehaviour
{
    public float length=10f;
    public GameObject target1;
    public GameObject target2;
    public VolumetricMultiLineBehavior line;
    public VolumetricMultiLineBehavior line2;
    public Vector3[] lineVertices;
    private float radius = 0.2f;
    private float intensityOfDot = 0.2f;
    private float density = 0.5f;
    private float time = 0f;
    private float mediumColor = 0.1f;
    private float colorVary;
    private float colorVarySpeed= 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        if(target1==null||target2==null){
            this.gameObject.SetActive(false);
            Debug.LogWarning("missing Object link on Spiral Line!!");
        }else{
            //target1 = this.transform.parent.gameObject;
            //target2=target1Script.door.gameObject;
            //Debug.Log(target1Script.door.name);
            float dx= target1.transform.position.x-target2.transform.position.x;
            float dz = target1.transform.position.z-target2.transform.position.z;
            //gameObject.transform.position=new Vector3(target1.transform.position.x,gameObject.transform.position.y,target1.transform.position.z);
            //Debug.Log(gameObject.transform.eulerAngles);
            length=Mathf.Sqrt(dx*dx+dz*dz)/density;
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
            //gameObject.transform.Rotate(0.0f, Mathf.Atan(dx/dz)*Mathf.Rad2Deg, 0.0f, Space.World);
        }
    }

    private bool stageShow = false;
    private int stageShowSwiftCD = 60;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,0.7f));
        time = time +colorVarySpeed;
        if(stageShow){
            // if constantly show only this
            colorVary=mediumColor*Mathf.Cos(time)+mediumColor*1.5f;
            if(stageShowSwiftCD == 0){
                stageShow = false;
                stageShowSwiftCD = 400;
            }
        }else{
            colorVary=0;
            if(stageShowSwiftCD == 0){
                stageShow = true;
                stageShowSwiftCD = 60;
            }
        }
        stageShowSwiftCD -= 1;
        line.LineColor= new Color(colorVary,colorVary,colorVary,1f);
        line2.LineColor= new Color(colorVary,colorVary,colorVary,1f);
        float dx= target1.transform.position.x-target2.transform.position.x;
        float dz = target1.transform.position.z-target2.transform.position.z;
        //Debug.Log(new Vector2(dx,dz));
        if(dz>=0){
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,Mathf.Atan(dx/dz)*Mathf.Rad2Deg+180,gameObject.transform.eulerAngles.z);
        }else{
            gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x,Mathf.Atan(dx/dz)*Mathf.Rad2Deg,gameObject.transform.eulerAngles.z);
        }
        gameObject.transform.position=new Vector3(target1.transform.position.x,gameObject.transform.position.y,target1.transform.position.z);
        gameObject.transform.localScale= new Vector3(1f,1f,Mathf.Sqrt(dx*dx+dz*dz)/length/density);
        if(target2.GetComponent<Door>()!=null && target2.GetComponent<Door>().isOpen==1){
            this.gameObject.SetActive(false);
        }
    }
}