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
    // Assign sessionID to identify playtests
    _session_ID = System.DateTime.Now.Ticks;
    // Send();
}


public void Send()
{
    Send(-1, "");
}

public void Send(int player, string reason)
{
    // Assign variables
    // PlayerA = (PlayerA)GameObject.Find("PlayerA");
    _a_score = PlayerA.score;
    _b_score = PlayerB.score;
    // System.DateTime moment = System.DateTime.Now;
    // int endTime = moment.Second;
    DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    long endTime = dto.ToUnixTimeSeconds();
    long _elapse_time = endTime-startTime;

    StartCoroutine(Post(_elapse_time.ToString(), player.ToString(), reason));
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
    form.AddField("entry.1019025330", _a_score.ToString());
    form.AddField("entry.1753151979", _b_score.ToString());
    form.AddField("entry.1376096949", elapse_time);// in second
    form.AddField("entry.1514440340", player);// cause die 0 for left ball, 1 for right ball, -1 pass level no death
    form.AddField("entry.1671652077", reason);// death reason, if pass, empty string 
    form.AddField("entry.1713748400", string.Join(",", check_point_times));
    form.AddField("entry.410156034", string.Join(",", coin_get_times));


    using (UnityWebRequest www = UnityWebRequest.Post(URL, form))
    {
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }
    }
}

Dictionary<string, int> check_point_name_to_idx = new Dictionary<string, int>();
Dictionary<string, int> coin_achieve_name_to_idx = new Dictionary<string, int>();

void initializeHashmaps(string cur_level){
    switch(cur_level) 
    {
    case "Level0.1":
        check_point_name_to_idx.Add("Coin (1)", 0);
        break;
    case "Level0":
        // code block
        break;
    case "Level1":
        // code block
        break;
    case "Level2":
        // code block
        break;
    case "Level3":
        // code block
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
        coin_get_times = new long[10];

        Debug.Log("start" + cur_level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
