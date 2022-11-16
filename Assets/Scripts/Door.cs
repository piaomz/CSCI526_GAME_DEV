using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public SendToGoogle sending;
    public int flagA = 0;
    public int flagB = 0;
    public int isOpen=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lift()
    {
        if (flagA ==1 && flagB==1 && isOpen==0) {
            isOpen=1;
            transform.position = new Vector3(transform.position.x,
                transform.position.y + (float)1.5, transform.position.z);
            sending.UpdateCheckPoint(gameObject.name);
        }
        
    }
}
