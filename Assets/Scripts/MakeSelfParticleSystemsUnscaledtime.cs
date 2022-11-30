using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSelfParticleSystemsUnscaledtime : MonoBehaviour
{



     void Update()
     {
        //  if (Time.timeScale < 0.01f)
         if (gameObject.activeSelf)
         {

            gameObject.GetComponent<ParticleSystem>().Simulate(Time.unscaledDeltaTime, true, false);
    
         }

     }
}
