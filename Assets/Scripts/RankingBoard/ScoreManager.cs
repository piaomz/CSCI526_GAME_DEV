using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ScoreManager : MonoBehaviour
{
    private ScoreData sd;

    void Awake()
    {
        sd = new ScoreData();
    }
    
//     public IEnumerator<Score> GetHighScores()
//     {
//         return sd.scores.OrderByDescending(x => x.product);
//     }
}
