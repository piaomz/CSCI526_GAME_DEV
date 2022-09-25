using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene3R2Play : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("PlayerA")){
            myAnimationController.SetBool("triggered", true);
            // myAnimationController.SetBool("triggered", false);
        }
    }
}
