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
        float h = Input.GetAxis("Horizontal");//-1 1
        float v = Input.GetAxis("Vertical");//ws
        rd.AddForce(new Vector3(600 * h * Time.fixedDeltaTime, 0, 600 * v * Time.fixedDeltaTime));
        if (transform.position.y < deadLiney)
        {
            score = 0;
            gameOverText.SetActive(true);
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Time.timeScale = 0;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter" + other.tag);
        if (other.tag == "CoinB")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "B Score : " + score;
            //if (score == 3)
            //{
            //    winText.SetActive(true);
            //}
        }
        else if(other.tag == "Enemy"){
            score=0;
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.tag == "RoadA")
        {
            score = 0;
            gameOverText.SetActive(true);
            gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Time.timeScale = 0;
        }
    }
}
