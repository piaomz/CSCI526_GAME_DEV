using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFloorA : MonoBehaviour
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
        if(other.tag == "PlayerA")
        {
            flag.SetActive(false);
            b1.isMoveA=false;
            b2.isMoveA=false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerA")
        {
            flag.SetActive(true);
            b1.isMoveA=true;
            b2.isMoveA=true;
        }
    }
}
