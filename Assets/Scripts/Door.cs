using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int flagA = 0;
    public int flagB = 0;
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
        if (flagA ==1 && flagB==1) {
            transform.position = new Vector3(transform.position.x,
                transform.position.y + 1, transform.position.z);
        }
        
    }
}
