using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingOneObj : MonoBehaviour
{

    public Transform playerTransform;
    private Vector3 offset;
    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;// fix Y
        pos.z = playerTransform.position.z + offset.z;
        pos.x = playerTransform.position.x + offset.x;
        transform.position = pos;
    }
}
