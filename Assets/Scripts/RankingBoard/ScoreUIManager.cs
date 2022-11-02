using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    public RowUi currentPlayerRowui;
    // public GameObject content;
    public RowUi rowuiPrefab;


    public void populateDataToTable(){
        if(GlobalVariables.currectPlayerScore.rank == -1){
            currentPlayerRowui.rank.text = "---";
        }else{
            currentPlayerRowui.rank.text = GlobalVariables.currectPlayerScore.rank.ToString();
        }
        currentPlayerRowui.player.text = GlobalVariables.currectPlayerScore.player+"(YOU)";
        currentPlayerRowui.product.text = GlobalVariables.currectPlayerScore.product.ToString();
        currentPlayerRowui.time.text = GlobalVariables.currectPlayerScore.time.ToString();
        for(int i = 0; i < GlobalVariables.scores.Count; i++){
            var row = Instantiate(rowuiPrefab, transform).GetComponent<RowUi>();
            row.rank.text = GlobalVariables.scores[i].rank.ToString();
            row.player.text = GlobalVariables.scores[i].player;
            row.product.text = GlobalVariables.scores[i].product.ToString();
            row.time.text = GlobalVariables.scores[i].time.ToString();
        }
    }
}
