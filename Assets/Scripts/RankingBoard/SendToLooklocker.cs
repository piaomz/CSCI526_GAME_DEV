using UnityEngine.UI;
using LootLocker.Requests;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SendToLooklocker : MonoBehaviour
{

    int currentLeaderboardID;
    // Start is called before the first frame update
    void Start()
    {
        LootLockerSDKManager.StartSession("frank232", (response) =>{
            if (response.success){
                Debug.Log("Leaderboard Session success");
            }else{
                Debug.Log("Leaderboard Session Failed");
            }
        });
        string cur_level = SceneManager.GetActiveScene().name;
        currentLeaderboardID = getLeaderboardID(cur_level);
    }

    private int getLeaderboardID(string cur_level){
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
    default:
        Debug.Log("out of scene name");
        return -1;
    }
}

    public void SubmitScore(int score){
        LootLockerSDKManager.SubmitScore(GlobalVariables.PlayerName, score, currentLeaderboardID, (response) =>{
            if (response.success){
                Debug.Log("Leaderboard Data uploaded");
            }else{
                Debug.Log("Leaderboard Data upload Failed");
            }
        });
    }

    int maxRowsToGet = 50;

    public void RequestScores()
    {
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
            }else{
                Debug.Log("Leaderboard Data get Failed");
            }
        });
    }

    public void RequestCurrentPlayerRankAndSet(int formattedScore){
            LootLockerSDKManager.GetMemberRank(currentLeaderboardID, GlobalVariables.PlayerName, (response) =>
            {
                if (response.success){
                    if(GlobalVariables.currectPlayerFormattedScore == response.score){
                        GlobalVariables.currectPlayerScore.rank = response.rank;
                    }
                }else{
                    Debug.Log("Leaderboard Single Data get Failed");
                }
            });
    }
}
