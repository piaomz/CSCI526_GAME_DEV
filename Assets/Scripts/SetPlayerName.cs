using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SetPlayerName : MonoBehaviour
{
    public GameObject inputField;
    public GameObject inputCanvas;
    void Start() {
        if(GlobalVariables.PlayerName.Length == 0){
            inputCanvas.SetActive(true);
        }else{
            inputCanvas.SetActive(false);
        }
        
    }

    // Start is called before the first frame update
    public void setNameAndHidePanel(){
        string inputText = inputField.GetComponent<TMP_InputField>().text;
        if(inputText.Length != 0){
            GlobalVariables.PlayerName = inputText;
            inputCanvas.SetActive(false);
        }
        // Debug.Log(GlobalVariables.PlayerName + " " + inputText);

    }
}
