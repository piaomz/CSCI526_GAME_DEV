using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualBoardControl : MonoBehaviour
{
    public Text ManualBoard;
    private bool show;
    // Start is called before the first frame update
    void Start()
    {
        show = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown("`"))
        {
            if(show)
            {
                ManualBoard.text = "`:manual";
                show = false;
            }
            else
            {
                ManualBoard.text = "'          :show and hide manual\nwasd  :control player 1\n↑↓←→:control player 2";
                show = true;
            }
        }
    }
}