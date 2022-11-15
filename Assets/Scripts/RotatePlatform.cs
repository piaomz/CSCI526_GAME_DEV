using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float rotationalSpeed = 0.1f;
    public bool left = false;
    public bool right = false;
    private float degZ;
    private Vector3 angles; // rotation degree

    void Start()
    {
        degZ = transform.localRotation.eulerAngles.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Rotate();
    }

    public void Rotate()
    {
        if (left || right)
        {
            // if pressed at the same time -> rotate left
            int dirParam = left ? 1 : -1;
                degZ += rotationalSpeed * dirParam;
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, degZ);
        }
    }
}
