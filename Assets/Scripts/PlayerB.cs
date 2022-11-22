using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerB : MonoBehaviour
{
    private Rigidbody rd;
    public int score = 0;
    public Text scoreText;
    public GameObject gameOverText;
    public int deadLiney = -3;
    public SendToGoogle sendingGForm;
    private float drag= 0.85f;
    public float maxV=25;
    private bool inertia;
    public Text deathReasonText;
    public int gravityScale = 1;
    //private GameObject winText;
    //private Rigidbody door;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.log("game start");
        rd = GetComponent<Rigidbody>();
        inertia = GlobalVariables.inertia;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rd.AddForce(Physics.gravity * gravityScale);
        float h = Input.GetAxis("Horizontal");//-1 1
        float v = Input.GetAxis("Vertical");//ws
        if(inertia){
            rd.AddForce(new Vector3(600*h * Time.fixedDeltaTime, 0, 600*v * Time.fixedDeltaTime));
        }else{
            if(gameObject.GetComponent<Rigidbody>().velocity.magnitude<maxV){
                rd.AddForce(new Vector3(3300 * h * Time.fixedDeltaTime, 0, 3300 * v * Time.fixedDeltaTime));
            }
            gameObject.GetComponent<Rigidbody>().velocity=new Vector3(gameObject.GetComponent<Rigidbody>().velocity.x*drag,gameObject.GetComponent<Rigidbody>().velocity.y,gameObject.GetComponent<Rigidbody>().velocity.z*drag);
            if(h<=0.2&& h>=-0.2 && v <= 0.2&&v>=-0.2){ 
            }
        }

        if (transform.position.y < deadLiney)
        {
            ExecuteDeath("Fall");
            // sendingGForm.Send();
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
        if (other.tag == "CoinB")
        {
            sendingGForm.UpdateCoinAchieve(other.gameObject.name);
            Destroy(other.gameObject);
            score++;
            scoreText.text = "B Score : " + score;
            //if (score == 3)
            //{
            //    winText.SetActive(true);
            //}
        }
        else if(other.tag == "Enemy"){
            ExecuteDeath("Touch Enemy");
            // score=0;
            // gameOverText.SetActive(true);
            // Time.timeScale = 0;
        }
        else if (other.tag == "RoadA")
        {
            ExecuteDeath("Touch different Color");
            // score = 0;
            // gameOverText.SetActive(true);
            // //gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            // //gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            // Time.timeScale = 0;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fallfloor")
        {
            Destroy(collision.gameObject, 0.5f);
        }
    }

    void ExecuteDeath(string reason){
        sendingGForm.SetDeath();
        sendingGForm.Send(1, reason);
        score = 0;
        deathReasonText.gameObject.SetActive(true);
        deathReasonText.text = "Death Reason :" + reason;
        gameOverText.SetActive(true);
        gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
        gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        Time.timeScale = 0;

    }
}
