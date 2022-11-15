using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateFloorRight : MonoBehaviour
{
    public RotatePlatform floor;
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
            floor.right = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerB")
        {
            flag.SetActive(true);
            floor.right = false;
        }
    }
}
