using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector1 : MonoBehaviour
{
    public string level;
    // Start is called before the first frame update

    public void OpenScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level" + level);
    }
}
