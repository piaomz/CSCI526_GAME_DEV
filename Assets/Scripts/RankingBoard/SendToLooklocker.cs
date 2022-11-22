using UnityEngine.UI;
using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SendToLooklocker : MonoBehaviour
{

    public TextMeshProUGUI ToLeaderboardButtonText;
    string cur_level;

    int currentLeaderboardID;
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartSession("waterskiing", (response) =>{
            if (response.success){
                Debug.Log("Leaderboard Session success");
            }else{
                Debug.Log("Leaderboard Session Failed");
            }
        });
        cur_level = SceneManager.GetActiveScene().name;
        currentLeaderboardID = getLeaderboardID(cur_level);
    }

    private int getLeaderboardID(string cur_level){
        if(GlobalVariables.inertia){
            switch(cur_level) 
            {
            case "Level0.1":
                return 8766;
            case "Level0":
                return 8765;
            case "Level1":
                return 8767;
            case "Level2":
                return 8768;
            case "Level3":
                return 8769;
            case "Level4":
                return 8869;
            case "Level5":
                return 8891;
            case "Level6":
                return 8893;
            case "Level7":
                return 9070;
            default:
                Debug.Log("out of scene name");
                return -1;
            }
        }else{
            // no inertia here
            switch(cur_level) 
            {
            case "Level0.1":
                return 8367;
            case "Level0":
                return 8364;
            case "Level1":
                return 8368;
            case "Level2":
                return 8369;
            case "Level3":
                return 8370;
            case "Level4":
                return 8868;
            case "Level5":
                return 8890;
            case "Level6":
                return 8892;
            case "Level7":
                return 9069;
            default:
                Debug.Log("out of scene name");
                return -1;
            }
        }


}

    public void SubmitScore(int score){
        // System.Threading.Thread.Sleep(3000);
        LootLockerSDKManager.SubmitScore(GlobalVariables.PlayerName, score, currentLeaderboardID, (response) =>{
            if (response.success){
                Debug.Log("Leaderboard Data uploaded");
                RequestScores();
            }else{
                Debug.Log("Leaderboard Data upload Failed");
            }
        });
    }

    int maxRowsToGet = 50;

    public void RequestScores()
    {
        // System.Threading.Thread.Sleep(2000);
        LootLockerSDKManager.GetScoreList(currentLeaderboardID, maxRowsToGet, (response) => {
            if (response.success){
                LootLockerLeaderboardMember[] scores = response.items;
                // Debug.Log(scores[0].rank +" "+ scores[0].member_id + " " + scores[0].score);
                // refresh
                GlobalVariables.scores = new List<Score>();
                for(int i = 0; i< scores.Length; i++)
                {
                    int product = scores[i].score / 1000000;
                    int time = 100000 - (scores[i].score%1000000);
                    GlobalVariables.scores.Add(new Score(scores[i].rank, scores[i].member_id, product, time));
                }
                Debug.Log("ALL Data get");
                RequestCurrentPlayerRankAndSet();
            }else{
                Debug.Log("Leaderboard Data get Failed");
            }
        });
    }

    public void RequestCurrentPlayerRankAndSet(){
            LootLockerSDKManager.GetMemberRank(currentLeaderboardID, GlobalVariables.PlayerName, (response) =>
            {
                if (response.success){
                    if(GlobalVariables.currectPlayerFormattedScore == response.score){
                        GlobalVariables.currectPlayerScore.rank = response.rank;
                    }
                    GlobalVariables.currectPlayerScore.player = GlobalVariables.PlayerName;
                    // GlobalVariables.currectPlayerScore.product = PlayerA.score * PlayerB.score;
                    GlobalVariables.currectPlayerScore.product = GlobalVariables.currectPlayerFormattedScore/ 1000000;
                    GlobalVariables.currectPlayerScore.time = (int)GlobalVariables.elapseTime;

                    GlobalVariables.allLeaderboardDataDownloaded = true;
                    Debug.Log("Single Data get");
                    setLoadedText();
                }else{
                    Debug.Log("Leaderboard Single Data get Failed");
                }
            });
    }

    private void setLoadedText(){
        ToLeaderboardButtonText.text = "Go to leaderboard";
    }
}
