using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator anim;
    private Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        lastPos=transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //AutoAnimation
        Vector3 towardPos = transform.position - lastPos;
        float speed = towardPos.magnitude / Time.deltaTime;
        //Debug.Log(speed);
        if(speed>0.01){
            anim.SetBool("Walk Forward", true);
        }else{
            anim.SetBool("Walk Forward", false);
        }
        lastPos=transform.position;
    }
}
