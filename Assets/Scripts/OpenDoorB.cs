using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorB : MonoBehaviour
{
    public Door door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerB")
        {
            print("open doorB");
            door.flagB = 1;
            door.SendMessage("Lift");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerB")
        {
            door.flagA = 0;
        }
    }
}
