using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ToNextLevel : MonoBehaviour
{
    public GameObject Button;
    public GameObject congratulationText;
    public string nextLevelName;
    // Start is called before the first frame update
    void Start()
    {
        Button.GetComponent<Button>().onClick.AddListener(NextLevel);
    }
    
    private void NextLevel(){
        Debug.Log("nextlevel");
        Time.timeScale = 1;
        SceneManager.LoadScene(nextLevelName);
    }
}
