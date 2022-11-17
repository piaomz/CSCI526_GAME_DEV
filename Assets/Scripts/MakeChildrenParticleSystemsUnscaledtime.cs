using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeChildrenParticleSystemsUnscaledtime : MonoBehaviour
{
ParticleSystem[] childrenParticleSystemComponents;

private void Start() {
    childrenParticleSystemComponents = GetComponentsInChildren<ParticleSystem>();
}

     void Update()
     {
        //  if (Time.timeScale < 0.01f)
         if (gameObject.activeSelf)
         {
            foreach (ParticleSystem childParticleSystemComponents in childrenParticleSystemComponents)
            {
                childParticleSystemComponents.Simulate(Time.unscaledDeltaTime, true, false);
            }
             
         }

     }
}
