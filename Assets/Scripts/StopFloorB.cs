using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFloorB : MonoBehaviour
{
    public Bridge b1;
    public Bridge b2;
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
            b1.isMove=false;
            b2.isMove=false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerB")
        {
            flag.SetActive(true);
            b1.isMove=true;
            b2.isMove=true;
        }
    }
}
