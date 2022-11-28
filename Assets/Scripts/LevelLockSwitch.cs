using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class LevelLockSwitch : MonoBehaviour
{
    public Button[] lvlButtons;

    int levelAt;

    void Start()
    {
        
    }

    public void LevelUnlock()
    {
        if (lvlButtons[lvlButtons.Length - 1].interactable == true)
        {
            levelAt = PlayerPrefs.GetInt("levelAt", 1);
            for (int i = 0; i < lvlButtons.Length; i++)
            {
                if (i + 1 > levelAt)
                    lvlButtons[i].interactable = false;
            }
            PlayerPrefs.SetInt("levelAt", 1);
        }
        else
        {
            for (int i = 0; i < lvlButtons.Length; i++)
            {
                    lvlButtons[i].interactable = true;
            }
            PlayerPrefs.SetInt("levelAt", SceneManager.sceneCountInBuildSettings-1);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
