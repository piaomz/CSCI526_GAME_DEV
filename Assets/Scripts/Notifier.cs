using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notifier : MonoBehaviour
{
    public bool visible;
    public PlayerA playerA;
    public PlayerB playerB;
    public Text textA;
    public Text textB;
    public Text textBarrier;
    public Coin coin;
    public GameObject barrier;

    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        textBarrier.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Input.GetKeyDown("h"))
        //    {
        //        text.gameObject.SetActive(!text.IsActive());
        //    }
        textA.gameObject.SetActive(playerA.transform.position.z < 1);
        textB.gameObject.SetActive(playerB.transform.position.z < 1);
        textBarrier.gameObject.SetActive((playerA.transform.position.z < barrier.transform.position.z &&
            playerA.transform.position.z > barrier.transform.position.z - 10) ||
            (playerB.transform.position.z < barrier.transform.position.z &&
            playerB.transform.position.z > barrier.transform.position.z - 10));
    }
}
