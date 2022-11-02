using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public ScoreUIManager UImanager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
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
            int reversedTime = 100000 - GlobalVariables.elapseTime;
            if (reversedTime < 0){
                reversedTime = 0;
            }
            // format score:      product                           time
            GlobalVariables.currectPlayerFormattedScore = PlayerA.score * PlayerB.score * 1000000 + reversedTime;
            sendingRanking.SubmitScore(GlobalVariables.currectPlayerFormattedScore);
            System.Threading.Thread.Sleep(200);
            sendingRanking.RequestScores();

            sendingRanking.RequestCurrentPlayerRankAndSet(GlobalVariables.currectPlayerFormattedScore);
            GlobalVariables.currectPlayerScore.player = GlobalVariables.PlayerName;
            GlobalVariables.currectPlayerScore.product = PlayerA.score * PlayerB.score;
            GlobalVariables.currectPlayerScore.time = GlobalVariables.elapseTime;
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
