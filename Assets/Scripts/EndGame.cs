using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject contratulationText;
    public GameObject theEndText;
    public SendToLooklocker sendingRanking;
    public PlayerA PlayerA;
    public PlayerB PlayerB;
    private int flagA = 0;
    private int flagB = 0;
    public SendToGoogle sendingGForm;
    // public TextMeshProUGUI ToLeaderboardButtonText;

    public ScoreUIManager UImanager;

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
        

    }

    // long ingameTimeElapse = 0;
    // long lastTime = 0;
    // int interval = 0;

    // private void FixedUpdate() {
    //     if (Time.timeScale > 0 && interval == 0){
    //         DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    //         long curTime = dto.ToUnixTimeMilliseconds();
    //         ingameTimeElapse += (long)(Time.timeScale * (curTime - lastTime));
    //         lastTime = curTime;
    //         float floatingameTimeElapse = (float)ingameTimeElapse / 1000;
    //         TimeBoard.text = String.Format("Time: {0:C2}s",floatingameTimeElapse.ToString());
    //         // interval = 10;
    //     }
    //     // interval -= 1;
    // }

    private void OnTriggerEnter(Collider other)
    {
        // sending.PrintStatus();
        if(other.tag == "PlayerA")
        {
            this.flagA = 1;
        }
        else if(other.tag == "PlayerB")
        {
            this.flagB = 1;
        }
        if(this.flagA ==1 && this.flagB ==1){
            Debug.Log("gameend");
            contratulationText.SetActive(true);
            if(theEndText){
                theEndText.SetActive(true);
            }
            // haven't separate a time manager out of "SendToGoogle"
            // so must update time in sending Gform first then leaderboard
            
            sendingGForm.Send();
            int reversedTime = 100000 - (int)GlobalVariables.elapseTime;
            if (reversedTime < 0){
                reversedTime = 0;
            }
            // format score:      product                           time
            GlobalVariables.currectPlayerFormattedScore = PlayerA.score * PlayerB.score * 1000000 + reversedTime;

            // not this condition
            // (not ) this game is single thread, so no locker or sequence needed, always upload then get all then get single
            sendingRanking.SubmitScore(GlobalVariables.currectPlayerFormattedScore);
            // all  below  are put in SubmitScore function now.
            // System.Threading.Thread.Sleep(200);
            // sendingRanking.RequestScores();

            // sendingRanking.RequestCurrentPlayerRankAndSet();
            // GlobalVariables.currectPlayerScore.player = GlobalVariables.PlayerName;
            // GlobalVariables.currectPlayerScore.product = PlayerA.score * PlayerB.score;
            // GlobalVariables.currectPlayerScore.time = GlobalVariables.elapseTime;

            // GlobalVariables.allLeaderboardDataDownloaded = true;
            // ToLeaderboardButtonText.text = "Go to leaderboard";

            Time.timeScale = 0;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerA")
        {
            this.flagA = 0;
        }
        else if(other.tag == "PlayerB")
        {
            this.flagB = 0;
        }
    }
}
