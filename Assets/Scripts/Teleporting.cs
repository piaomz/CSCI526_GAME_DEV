using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Teleporting : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform teleportTarget;
    public GameObject magicCircleAtStart;
    public GameObject magicCircleAtTarget;
    public GameObject pointLightAtStart;
    public GameObject pointLightAtTarget;
    public GameObject SplashAtStart;
    public GameObject SplashAtTarget;





    bool startAnimation = false;
    float dx;
    float dz;
    Collider ballToTeleport;
    Vector3 startPosition;
    Vector3 startTeleportPosition;
    float length1;

    void OnTriggerEnter(Collider other) {
        // directly transport
        // other.transform.position = teleportTarget.transform.position;

        resetAllParameters();
        Time.timeScale = 0;
        ballToTeleport = other;
        startPosition = other.transform.position;
        startTeleportPosition = gameObject.transform.position;
        dx = startTeleportPosition.x - startPosition.x;
        dz = startTeleportPosition.z - startPosition.z;
        // Debug.Log(dx.ToString() + " " + dz.ToString());
        length1 = (float)Math.Sqrt(dx*dx + dz*dz);
        dx /= length1;
        dz /= length1;
        // Debug.Log(dx.ToString() + " " + dz.ToString());
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        pointLightAtStart.GetComponent<Light>().intensity = lightIntensityS;
        pointLightAtTarget.GetComponent<Light>().intensity = lightIntensityT;
        pointLightAtStart.SetActive(true);
        pointLightAtTarget.SetActive(true);
        SplashAtStart.SetActive(true);
        SplashAtTarget.SetActive(true);
        IsMovingToCenter = true;
        startAnimation = true;
    }

    bool IsMovingToCenter = false;
    bool IsSpiralRising = false;
    bool EndStage = false;
    bool LandingStage = false;

    float rotateSpeed = 10f;
    float currentAngle = 0;
    float radius = 0;
    float maxRadius = 2;
    float radiusIncreaseSpeed = 0.2f;
    float yIncreaseSpeed = 0.05f;
    float lightIntensityS = 1;
    float lightIntensityT = 1;
    float lightIntensityMaxi = 3;
    float lightIntensityIncreasingSpeed = 20f;

    float yCeil = 10f;
    float ylandingSpeed = 5f;

    void resetAllParameters(){
        rotateSpeed = 10f;
        currentAngle = 0;
        radius = 0;
        maxRadius = 2;
        radiusIncreaseSpeed = 0.2f;
        yIncreaseSpeed = 0.05f;
        lightIntensityS = 1;
        lightIntensityT = 1;
    }

    private void Update() {
        if(startAnimation){
            if(IsMovingToCenter){
                Vector3 lastpos = ballToTeleport.transform.position;
                float realdx = dx*Time.unscaledDeltaTime;
                float realdz = dz*Time.unscaledDeltaTime;
                lastpos.x += realdx;
                lastpos.z += realdz;
                // Debug.Log(lastpos.ToString());
                length1 -= (float)Math.Sqrt(realdx*realdx + realdz*realdz);
                ballToTeleport.transform.position = lastpos;
                if(length1 <= 0){
                    IsMovingToCenter = false;
                    IsSpiralRising = true;
                }
                if(lightIntensityS < lightIntensityMaxi)
                {
                    lightIntensityS += lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                    lightIntensityT += lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                    pointLightAtStart.GetComponent<Light>().intensity = lightIntensityS;
                    pointLightAtTarget.GetComponent<Light>().intensity = lightIntensityT;
                }
            }
            else if(IsSpiralRising){
                if(radius < maxRadius){
                    radius += radiusIncreaseSpeed;
                }
                rotateSpeed += 0.01f;
                yIncreaseSpeed += 0.01f;
                currentAngle += rotateSpeed * (float)Math.PI;
                Vector3 lastpos = ballToTeleport.transform.position;
                lastpos.x = startTeleportPosition.x + (float)Mathf.Cos(currentAngle) * radius;
                lastpos.z = startTeleportPosition.z + (float)Mathf.Sin(currentAngle) * radius;
                lastpos.y += yIncreaseSpeed;
                ballToTeleport.transform.position = lastpos;
                if(lastpos.y > yCeil){
                    //end this stage
                    lastpos.x = teleportTarget.transform.position.x;
                    lastpos.z = teleportTarget.transform.position.z;
                    ballToTeleport.transform.position = lastpos;

                    IsSpiralRising = false;
                    IsSpiralRising = false;
                    LandingStage = true;
                    float temp = lightIntensityS;
                    lightIntensityS = lightIntensityT;
                    lightIntensityT = temp;
                }
                if(lightIntensityT < lightIntensityMaxi)
                {
                    lightIntensityT += lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                    pointLightAtTarget.GetComponent<Light>().intensity = lightIntensityT;
                }
                lightIntensityS += lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                pointLightAtStart.GetComponent<Light>().intensity = lightIntensityS;
            }else if(LandingStage){
                Vector3 lastpos = ballToTeleport.transform.position;
                lastpos.y -= yIncreaseSpeed;
                if(lastpos.y <= teleportTarget.transform.position.y + 0.5f){
                    LandingStage = false;
                    EndStage = true;
                }
                ballToTeleport.transform.position = lastpos;
                if(lightIntensityT > 0)
                {
                    lightIntensityT -= lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                    pointLightAtTarget.GetComponent<Light>().intensity = lightIntensityT;
                }
                if(lightIntensityS > 0)
                {
                    lightIntensityS -= lightIntensityIncreasingSpeed * Time.unscaledDeltaTime;
                    pointLightAtStart.GetComponent<Light>().intensity = lightIntensityS;
                }
            }

            else if(EndStage){
                gameObject.GetComponent<MeshRenderer>().enabled = true;
                pointLightAtStart.SetActive(false);
                pointLightAtTarget.SetActive(false);
                SplashAtStart.SetActive(false);
                SplashAtTarget.SetActive(false);
                ballToTeleport.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                Time.timeScale = 1;
                EndStage = false;
            }
        }    
    }
}
