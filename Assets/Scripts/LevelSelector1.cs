using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector1 : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OpenScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + level.ToString());
    }
}
