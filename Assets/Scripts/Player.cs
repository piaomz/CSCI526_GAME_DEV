using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rd;
    public int score = 0;
    public Text scoreText;
    public GameObject winText;
    public Rigidbody door;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.log("game start");
      rd = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Loading");
        //rd.AddForce(Vector3.right);
        //rd.AddForce(new Vector3(2, 0, 0));

        float h = Input.GetAxis("Horizontal");//-1 1
        float v = Input.GetAxis("Vertical");//ws
        rd.AddForce(new Vector3(h, 0, v));
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("peng OnCollisionEnter");
        
            if (collision.gameObject.tag=="food")
        {
            Destroy(collision.gameObject);
        }
    }


    //private void OnCollisionStay(Collision collision)
    //{
    //    Debug.Log("peng");   
    //}
    //private void OnCollisionExit(Collision collision)
    //{
    //    Debug.Log("peng");
    //}
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter" + other.tag);
        if (other.tag == "food")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "score:" + score;
            if (score == 3)
            {
                winText.SetActive(true);
            }
        }

        
        
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("OnTriggerExit" + other.tag);

    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("OnTriggerStay" + other.tag);
    //}
}
