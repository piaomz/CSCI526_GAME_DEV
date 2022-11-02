using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public int rank;
    public string player;
    public int product;
    public int time;

    public Score(int rank, string player, int product, int time){
        this.rank = rank;
        this.player = player;
        this.product = product;
        this.time = time;
    }

    public Score(){
        this.rank = -1;
        this.player = "";
        this.product = 0;
        this.time = 1000000;
    }
}
