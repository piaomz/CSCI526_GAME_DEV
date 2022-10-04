using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public GameObject contratulationText;
    public GameObject theEndText;
    private int flagA = 0;
    private int flagB = 0;

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
        if(other.tag == "PlayerA")
        {
            this.flagA = 1;
        }
        else if(other.tag == "PlayerB")
        {
            this.flagB = 1;
        }
        if(this.flagA ==1 && this.flagB ==1){
            Debug.Log("gameend");
            contratulationText.SetActive(true);
            if(theEndText){
                theEndText.SetActive(true);
            }
            Time.timeScale = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerA")
        {
            this.flagA = 0;
        }
        else if(other.tag == "PlayerB")
        {
            this.flagB = 0;
        }
    }
}
