using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerA : MonoBehaviour
{
    private Rigidbody rd;
    private int score = 0;
    public Text scoreText;
    //private GameObject winText;
    //private Rigidbody door;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.log("game start");
        rd = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal2");//-1 1
        float v = Input.GetAxis("Vertical2");//ws
        rd.AddForce(new Vector3(h, 0, v));
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
    }

}
