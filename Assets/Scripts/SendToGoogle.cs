using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class SendToGoogle : MonoBehaviour
{

    [SerializeField] public string URL;
    private long _sessionID;
    private int _a_score;
    private int _b_score;
    private long _gg_time;
    private long startTime;

    // public PlayerA PlayerA;
    public PlayerA PlayerA;
    public PlayerB PlayerB;

    private void Awake()
{
    // Assign sessionID to identify playtests
    _sessionID = System.DateTime.Now.Ticks;
    // Send();
}

public void Send()
{
    // Assign variables
    // PlayerA = (PlayerA)GameObject.Find("PlayerA");
    _a_score = PlayerA.score;
    Debug.Log(_a_score);
    // _b_score = PlayerB.score;
    // _a_score = 0;
    _b_score = PlayerB.score;
    // System.DateTime moment = System.DateTime.Now;
    // int endTime = moment.Second;
    DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
    long endTime = dto.ToUnixTimeSeconds();
    _gg_time = endTime-startTime;

    StartCoroutine(Post(_sessionID.ToString(), _a_score.ToString(), _b_score.ToString(), _gg_time.ToString()));
}

private IEnumerator Post(string sessionID, string a_score, string b_score, string gg_time)
{
    WWWForm form = new WWWForm();
    form.AddField("entry.1651845501", sessionID);
    form.AddField("entry.1019025330", a_score);
    form.AddField("entry.1753151979", b_score);
    form.AddField("entry.1376096949", gg_time);

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


    // Start is called before the first frame update
    void Start()
    {
        // Get the offset from current time in UTC time
        DateTimeOffset dto = new DateTimeOffset(DateTime.UtcNow);
        // Get the unix timestamp in seconds
        startTime = dto.ToUnixTimeSeconds();
        // System.DateTime moment = System.DateTime.Now;
        // startTime = moment.Second;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
