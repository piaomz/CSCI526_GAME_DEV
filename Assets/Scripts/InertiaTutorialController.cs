using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaTutorialController : MonoBehaviour
{
    public GameObject InertiaTutorial;
    // Start is called before the first frame update
    void Start()
    {
        if (GlobalVariables.inertia)
        {
            InertiaTutorial.SetActive(true);
        }
        else{
            InertiaTutorial.SetActive(false);
        }
    }

}
