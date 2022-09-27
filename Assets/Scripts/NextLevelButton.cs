using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevelButton : MonoBehaviour
{
    public GameObject Button;
    public GameObject congratulationText;
    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Button>().onClick.AddListener(NextLevel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void NextLevel(){
        Debug.Log("nextlevel");
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

        congratulationText.SetActive(false);
        SceneManager.LoadScene(nextLevelName);
    }
}
