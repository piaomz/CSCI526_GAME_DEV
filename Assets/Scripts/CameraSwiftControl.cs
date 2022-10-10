using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwiftControl : MonoBehaviour
{
    public GameObject CameraA;
    public GameObject CameraB;
    public GameObject CameraTogether;
    private bool together;


    private bool is_original_angle;
    private Vector3 original_angle_position;
    private Quaternion original_angle_rotation;
    private float original_FOV = 50; 
    private Vector3 upper_angle_position;
    private Quaternion upper_angle_rotation;
    private float upper_FOV = 15; 
    // Start is called before the first frame update
    void Start()
    {
        together = false;
        is_original_angle = true;
        original_angle_position = new Vector3(0, (float)11, -11);
        original_angle_rotation = Quaternion.Euler((float)29.3, 0, 0);
        // original_angle_rotation = new Vector3((float)29.3, 0, 0);
        upper_angle_position = new Vector3(0, (float)33.5, -35);
        upper_angle_rotation = Quaternion.Euler(39, 0, 0);
        // upper_angle_rotation = new Vector3(39, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("v"))
        {
            if(together)
            {
                CameraA.SetActive(false);
                CameraB.SetActive(false);
                CameraTogether.SetActive(true);
                together = false;
            }
            else
            {
                CameraA.SetActive(true);
                CameraB.SetActive(true);
                CameraTogether.SetActive(false);
                together = true;
            }
        }
        if (Input.GetKeyDown("b"))
        {
            if(is_original_angle)
            {
                CameraA.transform.position = original_angle_position;
                CameraA.transform.rotation = original_angle_rotation;
                CameraA.GetComponent<Camera>().fieldOfView = original_FOV;
                CameraA.GetComponent<CameraFollowingOneObj>().SetOffset(original_angle_position);
                CameraB.transform.position = original_angle_position;
                CameraB.transform.rotation = original_angle_rotation;
                CameraB.GetComponent<Camera>().fieldOfView = original_FOV;
                CameraB.GetComponent<CameraFollowingOneObj>().SetOffset(original_angle_position);
                CameraTogether.transform.position = original_angle_position;
                CameraTogether.transform.rotation = original_angle_rotation;
                CameraTogether.GetComponent<Camera>().fieldOfView = original_FOV;
                CameraTogether.GetComponent<CameraMainFollowing>().SetOffset(original_angle_position);
                is_original_angle = false;
            }
            else
            {
                CameraA.transform.position = upper_angle_position;
                CameraA.transform.rotation = upper_angle_rotation;
                CameraA.GetComponent<Camera>().fieldOfView = upper_FOV;
                CameraA.GetComponent<CameraFollowingOneObj>().SetOffset(upper_angle_position);
                CameraB.transform.position = upper_angle_position;
                CameraB.transform.rotation = upper_angle_rotation;
                CameraB.GetComponent<Camera>().fieldOfView = upper_FOV;
                CameraB.GetComponent<CameraFollowingOneObj>().SetOffset(upper_angle_position);
                CameraTogether.transform.position = upper_angle_position;
                CameraTogether.transform.rotation = upper_angle_rotation;
                CameraTogether.GetComponent<Camera>().fieldOfView = upper_FOV;
                CameraTogether.GetComponent<CameraMainFollowing>().SetOffset(upper_angle_position);
                is_original_angle = true;
            }
        }
    }
}