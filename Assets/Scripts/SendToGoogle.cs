using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System;

public class SendToGoogle : MonoBehaviour
{

    [SerializeField] public string URL;
    private long _session_ID;
    private int _a_score;
    private int _b_score;
    private long startTime;

    // public PlayerA PlayerA;
    public PlayerA PlayerA;
    public PlayerB PlayerB;

    private bool is_live;

    private string cur_level;

    private long[] check_point_times;
    private long[] coin_get_times;

    private void Awake()
{
    // just in case when testing
    // Assign sessionID to identify playtests
    if(GlobalVariables._session_ID == 0)
    {
        _session_ID = System.DateTime.Now.Ticks;
        GlobalVariables._session_ID = _session_ID;
    }
    else{
        _session_ID = GlobalVariables._session_ID;
    }
    // Debug.Log(_session_ID);
    
    // DontDestroyOnLoad(gameObject);
    // Send();
}

public void Send()
{
    Send(-1, "");
}

public void Send(int player, string reason)
{
    // // Assign variables
    // // PlayerA = (PlayerA)GameObject.Find("PlayerA");
    // _a_score = PlayerA.score;
    // _b_score = PlayerB.score;
    // // System.DateTime moment = System.DateTime.Now;
    // // int endTime = moment.Second;
    // DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    // long endTime = dto.ToUnixTimeSeconds();
    // long _elapse_time = endTime-startTime;
    // // GlobalVariables.elapseTime = (int)_elapse_time;
    // Debug.Log(((int)_elapse_time).ToString() + "  ---  " +  GlobalVariables.elapseTime.ToString());

    StartCoroutine(Post(GlobalVariables.elapseTime.ToString(), player.ToString(), reason));
}

public void PrintStatus(){
    Debug.Log(string.Join(",", coin_get_times));
}

public void UpdateCheckPoint(string check_point_name){
    int index = check_point_name_to_idx[check_point_name];
    // only when first time reach
    if(check_point_times[index] == 0){
        DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
        long endTime = dto.ToUnixTimeSeconds();
        long _elapse_time = endTime-startTime;
        check_point_times[index] = _elapse_time;
    }
}

public void UpdateCoinAchieve(string coin_achieve_name){
    int index = coin_achieve_name_to_idx[coin_achieve_name];
    DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    long endTime = dto.ToUnixTimeSeconds();
    long _elapse_time = endTime-startTime;
    coin_get_times[index] = _elapse_time;
}

public void SetDeath(){
    is_live = false;
}

private IEnumerator Post(string elapse_time, string player, string reason)
{
    WWWForm form = new WWWForm();
    form.AddField("entry.1651845501", _session_ID.ToString());// end timestamp
    form.AddField("entry.1038671093", cur_level);
    form.AddField("entry.996748938", is_live.ToString());// true live, false died
    form.AddField("entry.1019025330", _a_score.ToString());// score when die or pass level
    form.AddField("entry.1753151979", _b_score.ToString());
    form.AddField("entry.1376096949", elapse_time);// in second
    form.AddField("entry.1514440340", player);// cause die 0 for left ball, 1 for right ball, -1 pass level no death
    form.AddField("entry.1671652077", reason);// death reason, if pass, empty string 
    form.AddField("entry.1713748400", string.Join(",", check_point_times));
    // check point: gate, sorted(mapped) by distance from start, store finish check point time, check_point_times[i]: pass time at check point i, length == max(points from levels)
    form.AddField("entry.410156034", string.Join(",", coin_get_times));// coin time
    form.AddField("entry.1401706524", GlobalVariables.inertia.ToString());// GlobalVariables.inertia


    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
    {
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Analytical data upload complete!");
        }
    }
}

Dictionary<string, int> check_point_name_to_idx = new Dictionary<string, int>();
Dictionary<string, int> coin_achieve_name_to_idx = new Dictionary<string, int>();

void initializeHashmaps(string cur_level){
    switch(cur_level) 
    {
    case "Level0.1":
        coin_achieve_name_to_idx.Add("Coin (2)", 0);
        coin_achieve_name_to_idx.Add("CoinB (2)", 1);
        coin_achieve_name_to_idx.Add("Coin (1)", 2);
        coin_achieve_name_to_idx.Add("CoinB (1)", 3);
        coin_achieve_name_to_idx.Add("Coin (4)", 4);
        coin_achieve_name_to_idx.Add("CoinB (4)", 5);
        check_point_name_to_idx.Add("doorA", 0);
        check_point_name_to_idx.Add("doorB", 1);
        break;
    case "Level0":
        coin_achieve_name_to_idx.Add("Coin (6)", 0);
        coin_achieve_name_to_idx.Add("CoinB (6)", 1);
        coin_achieve_name_to_idx.Add("Coin (4)", 2);
        coin_achieve_name_to_idx.Add("CoinB (4)", 3);
        coin_achieve_name_to_idx.Add("Coin (5)", 4);
        coin_achieve_name_to_idx.Add("CoinB (5)", 5);
        break;
    case "Level1":
        coin_achieve_name_to_idx.Add("Coin (3)", 0);
        coin_achieve_name_to_idx.Add("CoinB (3)", 1);
        coin_achieve_name_to_idx.Add("Coin (2)", 2);
        coin_achieve_name_to_idx.Add("CoinB (2)", 3);
        coin_achieve_name_to_idx.Add("Coin (1)", 4);
        coin_achieve_name_to_idx.Add("CoinB (1)", 5);
        coin_achieve_name_to_idx.Add("Coin (5)", 6);
        coin_achieve_name_to_idx.Add("CoinB (5)", 7);
        coin_achieve_name_to_idx.Add("Coin (4)", 8);
        coin_achieve_name_to_idx.Add("CoinB (4)", 9);
        coin_achieve_name_to_idx.Add("Coin (6)", 10);
        coin_achieve_name_to_idx.Add("CoinB (6)", 11);
        check_point_name_to_idx.Add("doorAB", 0);
        break;
    case "Level2":
        coin_achieve_name_to_idx.Add("Coin (3)", 0);
        coin_achieve_name_to_idx.Add("CoinB (3)", 1);
        coin_achieve_name_to_idx.Add("Coin (2)", 2);
        coin_achieve_name_to_idx.Add("CoinB (2)", 3);
        coin_achieve_name_to_idx.Add("Coin (1)", 4);
        coin_achieve_name_to_idx.Add("CoinB (1)", 5);
        coin_achieve_name_to_idx.Add("Coin (4)", 6);
        coin_achieve_name_to_idx.Add("CoinB (4)", 7);
        coin_achieve_name_to_idx.Add("CoinB (5)", 8);
        coin_achieve_name_to_idx.Add("Coin (5)", 9);
        check_point_name_to_idx.Add("doorA", 0);
        check_point_name_to_idx.Add("doorB", 1);
        check_point_name_to_idx.Add("doorAB", 3);
        break;
    case "Level3":
        coin_achieve_name_to_idx.Add("Coin (3)", 0);
        coin_achieve_name_to_idx.Add("CoinB (3)", 1);
        coin_achieve_name_to_idx.Add("Coin (1)", 2);
        coin_achieve_name_to_idx.Add("CoinB (1)", 3);
        coin_achieve_name_to_idx.Add("Coin (2)", 4);
        coin_achieve_name_to_idx.Add("CoinB (2)", 5);
        check_point_name_to_idx.Add("doorA", 0);
        check_point_name_to_idx.Add("doorB", 1);
        check_point_name_to_idx.Add("doorAB", 3);
        // code block
        break;
    case "Levelmovingfloor":
        coin_achieve_name_to_idx.Add("Coin (1)", 0);
        coin_achieve_name_to_idx.Add("CoinB (1)", 1);
        coin_achieve_name_to_idx.Add("Coin (2)", 2);
        coin_achieve_name_to_idx.Add("CoinB (2)", 3);
        break;
    case "Levelfallfloor":
        coin_achieve_name_to_idx.Add("Coin (1)", 0);
        coin_achieve_name_to_idx.Add("CoinB (1)", 1);
        coin_achieve_name_to_idx.Add("Coin (2)", 2);
        coin_achieve_name_to_idx.Add("CoinB (2)", 3);
        break;
    case "LevelRotateFloor":
        // coin_achieve_name_to_idx.Add("Coin (1)", 0);
        // coin_achieve_name_to_idx.Add("CoinB (1)", 1);
        // coin_achieve_name_to_idx.Add("Coin (2)", 2);
        // coin_achieve_name_to_idx.Add("CoinB (2)", 3);
        break;
    default:
        // code block
        break;
    }

}


    // Start is called before the first frame update
    void Start()
    {
        // Get the offset from current time in UTC time
        DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
        // Get the unix timestamp in seconds
        startTime = dto.ToUnixTimeSeconds();
        // System.DateTime moment = System.DateTime.Now;
        // startTime = moment.Second;

        // initialize
        cur_level = SceneManager.GetActiveScene().name;
        initializeHashmaps(cur_level);
        is_live = true;
        check_point_times = new long[10];
        coin_get_times = new long[12];

        // Debug.Log("start" + cur_level);
    }


}
