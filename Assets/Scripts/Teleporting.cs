using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    // public GameObject thePlayer;

    void OnTriggerEnter(Collider other) {
        other.transform.position = teleportTarget.transform.position;
    }
}
