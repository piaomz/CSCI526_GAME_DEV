using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool isMoveA=true;
    public bool isMoveB=true;
    public float speed =0.1f;
    public int direction = 1;
    public float startX=-8.5f;
    public float endX=6.3f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        if(direction==-1){
            float dumy = startX;
            startX=endX;
            endX=dumy;
        }
        startPos=transform.position;
        startPos.x=startX;
        transform.position=startPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(direction==1){
            if(transform.position.y<-3){
                transform.position= new Vector3(startPos.x,-2.9f,startPos.z);
            }
            else if(transform.position.x==startPos.x && transform.position.y>-3 && transform.position.y<startPos.y){
                transform.position= transform.position+ (new Vector3(0,speed*0.5f,0));
            }
            else if(transform.position.x>endX){
                transform.position= transform.position+ (new Vector3(0,speed*-0.5f,0));
            }
            else if(isMoveA==true&&isMoveB==true){
                transform.position=transform.position + (new Vector3(speed,0,0));
        }
        }else{
            if(transform.position.y<-3){
                transform.position= new Vector3(startPos.x,-2.9f,startPos.z);
            }
            else if(transform.position.x==startPos.x && transform.position.y>-3 && transform.position.y<startPos.y){
                transform.position= transform.position+ (new Vector3(0,speed*0.5f,0));
            }
            else if(transform.position.x<endX){
                transform.position= transform.position+ (new Vector3(0,speed*-0.5f,0));
            }
            else if(isMoveA==true&&isMoveB==true){
                transform.position=transform.position + (new Vector3(speed*-1,0,0));
            }
        }
        
        
    }
}
