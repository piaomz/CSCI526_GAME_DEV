using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform playerTransform;
    public Transform playerTransform2;
    private Vector3 offset;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        //pos = (playerTransform.position + playerTransform2.position) / 2;
        offset = transform.position - (playerTransform.position + playerTransform2.position) / 2;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = (playerTransform.position + playerTransform2.position) / 2 + offset;

        pos = transform.position;
        if (playerTransform.position.z < playerTransform2.position.z)
        {
            pos.z = playerTransform.position.z + offset.z;
        }
        else {
            pos.z = playerTransform2.position.z + offset.z;
        }
        //pos.z = playerTransform.position.z, playerTransform2.position.z + offset.z;
        transform.position = pos;
    }
}
