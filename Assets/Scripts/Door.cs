using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SendToGoogle sending;
    public int flagA = 0;
    public int flagB = 0;
    public int isOpen=0;
    private int isMove2Place=0;
    private float initalY;
    // Start is called before the first frame update
    void Start()
    {
        initalY=transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isOpen==1 && isMove2Place==0){
            transform.position = new Vector3(transform.position.x,transform.position.y + 0.05f, transform.position.z);
            if(transform.position.y>=initalY+1.5f){
                isMove2Place=1;
            }
        }
    }
    public void Lift()
    {
        if (flagA ==1 && flagB==1 && isOpen==0) {
            isOpen=1;
            sending.UpdateCheckPoint(gameObject.name);
        }
    }
}
