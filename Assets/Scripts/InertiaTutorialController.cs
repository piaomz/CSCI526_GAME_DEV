using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaTutorialController : MonoBehaviour
{
    public bool showed;
    public GameObject TutorialCanvas;
    void Start(){
        showed = false;
    }

    public void clicked() {
        if(GlobalVariables.inertia && !showed){
            TutorialCanvas.SetActive(true);
            showed = true;// show once
        }
    }

    private void Update() {
        if(TutorialCanvas.activeSelf && Input.GetKeyDown(KeyCode.Space)){
            closeCanvas();
        }
    }

    public void closeCanvas(){
        TutorialCanvas.SetActive(false);
    }

}
