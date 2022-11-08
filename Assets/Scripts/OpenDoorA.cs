using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorA : MonoBehaviour
{
    public Door door;
    private GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        flag = this.gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerA")
        {
            flag.SetActive(false);
            print("open doorA");
            door.flagA = 1;
            door.SendMessage("Lift");
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerA" && door.isOpen == 0)
        {
            flag.SetActive(true);
            door.flagA = 0;
        }
    }
}
