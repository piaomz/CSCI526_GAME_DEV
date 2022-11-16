using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if (other.tag=="Enemy"){
            //Debug.Log("111");
            gameObject.SetActive(false);
        }
    }
}
