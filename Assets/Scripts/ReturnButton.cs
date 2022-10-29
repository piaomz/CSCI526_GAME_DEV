using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ReturnButton : MonoBehaviour
{
    public GameObject playerA;
    public GameObject playerB;
    public GameObject Button;
    public GameObject gameOverText;
    public Text scoreTextA;
    public Text scoreTextB;
    public Text deathReasonText;
    private Vector3 posA;
    private Vector3 posB;
    // Start is called before the first frame update
    void Start()
    {
        posA= playerA.transform.position;
        posB= playerB.transform.position;
        Button.GetComponent<Button>().onClick.AddListener(ReturnToStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void ReturnToStart(){
        Debug.Log("return to start");
        Time.timeScale = 1;
        //layerA.transform.position=posA;
        //playerA.transform.localEulerAngles = new Vector3 (0, 0, 0);
        //playerA.GetComponent<Rigidbody>().angularVelocity=new Vector3(0,0,0);
        //playerA.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
        //PlayerA.score=0;
        //scoreTextA.text = "A Score : 0" ;

        //playerB.transform.position=posB;
        //playerB.transform.localEulerAngles = new Vector3 (0, 0, 0);
        //playerB.GetComponent<Rigidbody>().angularVelocity=new Vector3(0,0,0);
        //playerB.GetComponent<Rigidbody>().velocity=new Vector3(0,0,0);
        //PlayerB.score=0;
        //scoreTextB.text = "B Score : 0" ;
        deathReasonText.gameObject.SetActive(false);
        gameOverText.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
