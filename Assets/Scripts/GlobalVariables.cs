using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalVariables
{
    public static long _session_ID = 0; 
    public static bool inertia = false;
    public static string PlayerName = "test2";
    public static float elapseTime = 0;
    public static List<Score> scores = new List<Score>();
    public static Score currectPlayerScore = new Score();
    public static int currectPlayerFormattedScore = 0;
    public static bool allLeaderboardDataDownloaded = false;
}