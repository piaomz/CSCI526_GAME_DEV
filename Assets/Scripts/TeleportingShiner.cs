using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportingShiner : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    public GameObject teleportTargetPositionLight;
    // public GameObject thePlayer;

    void OnTriggerEnter(Collider other) {
        teleportTargetPositionLight.SetActive(true);
    }
    void OnTriggerExit(Collider other){
        teleportTargetPositionLight.SetActive(false);
    }
}
