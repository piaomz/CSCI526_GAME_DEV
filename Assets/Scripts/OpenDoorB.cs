using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorB : MonoBehaviour
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
        if(other.tag == "PlayerB")
        {
            flag.SetActive(false);
            print("open doorB");
            door.flagB = 1;
            door.SendMessage("Lift");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerB")
        {
            flag.SetActive(true);
            door.flagB = 0;
        }
    }
}
