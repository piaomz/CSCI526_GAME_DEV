using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPopupController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool showed;
    public GameObject TutorialCanvas;
    void Start(){
        showed = false;
    }

    void OnTriggerEnter(Collider other) {
        if(!showed){
            TutorialCanvas.SetActive(true);
            showed = true;// show once
            Time.timeScale = 0;
        }
    }

    public void closeCanvas(){
        TutorialCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
