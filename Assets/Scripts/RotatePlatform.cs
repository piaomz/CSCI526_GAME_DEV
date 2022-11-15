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

    // dir is right | left
    public void Rotate()
    {
        if (left || right)
        {
            Debug.Log("===========Rotating===========" + Math.Abs(degZ));
            int dirParam = left ? 1 : -1;
            // stop if deg >= 60
            // if (Math.Abs(degZ) < 60f)
            // {
                degZ += rotationalSpeed * dirParam;
                transform.localRotation = Quaternion.Euler(0.0f, 0.0f, degZ);
            // }
        }
    }
}
