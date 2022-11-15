using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class TimeBoardUpdater : MonoBehaviour
{
    public Text TimeBoard;

    // Start is called before the first frame update
    void Start()
    {
        // DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
        // lastTime = dto.ToUnixTimeMilliseconds();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale > 0){
            curTime += Time.deltaTime;
            TimeBoard.text = String.Format("{0:.0}", curTime);
            GlobalVariables.elapseTime = curTime;
        }

    }

    // long ingameTimeElapse = 0;
    // long lastTime = 0;
    float curTime = 0;
    // int interval = 0;

    // private void FixedUpdate() {
    //     if (Time.timeScale > 0 && interval == 0){
    //         DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    //         long curTime = dto.ToUnixTimeMilliseconds();
    //         ingameTimeElapse += (long)(Time.timeScale * (curTime - lastTime));
    //         lastTime = curTime;
    //         float floatingameTimeElapse = (float)ingameTimeElapse / 1000;
    //         TimeBoard.text = String.Format("Time: {0:C2}s",floatingameTimeElapse.ToString());
    //         Debug.Log(TimeBoard.text);
    //         interval = 10;
    //     }
    //     interval -= 1;
    // }
}
