using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenetu : MonoBehaviour
{
    [SerializeField] private Animator EnemyAnimator;
    [SerializeField] private Animator ChestAnimator;
    private bool isChestOpen=false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerA") || other.CompareTag("PlayerB"))
        {
            EnemyAnimator.SetBool("triggered", true);
            if(isChestOpen==false){
                ChestAnimator.SetTrigger("open");
            }
            isChestOpen=true;
            // myAnimationController.SetBool("triggered", false);
        }
    }
}
