using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenetu : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerA") || other.CompareTag("PlayerB"))
        {
            myAnimationController.SetBool("triggered", true);
            // myAnimationController.SetBool("triggered", false);
        }
    }
}
