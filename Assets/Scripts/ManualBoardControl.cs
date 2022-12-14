using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualBoardControl : MonoBehaviour
{
    public Text ManualBoard;
    public GameObject ManualBoardBKG;
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
        if (Input.GetKeyDown("c"))
        {
            if(show)
            {
                ManualBoard.text = "c:manual";
                show = false;
                ManualBoardBKG.SetActive(false);
            }
            else
            {
                ManualBoard.text = "c         :show and hide manual\nwasd  :control player 1\narrows:control player 2\nv         :separate view or not\nb         :change view angle\nshift :press to see widerly temporally";
                show = true;
                ManualBoardBKG.SetActive(true);
            }
        }
    }
}