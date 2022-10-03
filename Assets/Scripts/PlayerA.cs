using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ShowPopupExample : EditorWindow
{
    [MenuItem("Example/ShowPopup Example")]
    static void Init()
    {
        ShowPopupExample window = ScriptableObject.CreateInstance<ShowPopupExample>();
        window.position = new Rect(Screen.width / 2, Screen.height / 2, 250, 150);
        window.ShowPopup();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("This is an example of EditorWindow.ShowPopup", EditorStyles.wordWrappedLabel);
        GUILayout.Space(70);
        if (GUILayout.Button("Agree!")) this.Close();
    }
}

public class PlayerA : MonoBehaviour
{
    private Rigidbody rd;
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverText;
    public int deadLiney = -3;
    public SendToGoogle sending;
    //private GameObject winText;
    //private Rigidbody door;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.log("game start");
        rd = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal2");//-1 1
        float v = Input.GetAxis("Vertical2");//ws
        rd.AddForce(new Vector3(600*h * Time.fixedDeltaTime, 0, 600*v * Time.fixedDeltaTime));
        if (transform.position.y < deadLiney)
        {
            ExecuteDeath("Fall");
            // score = 0;
            // gameOverText.SetActive(true);
            
            // //gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // Time.timeScale = 0;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter" + other.tag);
        if (other.tag == "CoinA")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "A Score : " + score;
            //if (score == 3)
            //{
            //    winText.SetActive(true);
            //}
        }
        else if(other.tag == "Enemy")
        {
            ExecuteDeath("Touch Enemy");
            // score=0;
            // gameOverText.SetActive(true);
            // //gameObject.transform.localEulerAngles = new Vector3 (0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().angularVelocity=new Vector3(0,0,0);
            // //gameObject.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
            // Time.timeScale = 0;
        }
        else if (other.tag == "RoadB")
        {
            ExecuteDeath("Touch different Color");
            // score = 0;
            // gameOverText.SetActive(true);
            // //gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // Time.timeScale = 0;
        }
        else if (other.tag == "Notifier")
        {
           

        }
    }

    void ExecuteDeath(string reason){
        sending.Send(0, reason);
        score = 0;
        gameOverText.SetActive(true);
        Time.timeScale = 0;
    }
}
