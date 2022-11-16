using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class WorldSwitch : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        if(GlobalVariables.inertia){
            text.text = "Heavy(hard)";
            text.color = Color.red;
        }else{
            text.text = "Light(easy)";
            text.color = Color.green;
        }
    }

    public void WorldSwift(){
        if(GlobalVariables.inertia){
            GlobalVariables.inertia = false;
            text.text = "Light(easy)";
            text.color = Color.green;
        }else{
            GlobalVariables.inertia = true;
            text.text = "Heavy(hard)";
            text.color = Color.red;
        }
        // Debug.Log(GlobalVariables.inertia);
    }
}
