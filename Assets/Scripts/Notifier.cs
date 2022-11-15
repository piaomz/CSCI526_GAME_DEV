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
    public GameObject water;
    public Text textCoin;
    public GameObject barrier;
    public GameObject colorZone;
    public GameObject colorEndGame;
    public Text textColorZone;
    public Text textEndGame;
    public Text textCongrats;

    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        textA.gameObject.SetActive(false);
        textB.gameObject.SetActive(false);
        textBarrier.gameObject.SetActive(false);
        textCoin.gameObject.SetActive(false);
        textColorZone.gameObject.SetActive(false);
        textEndGame.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
       
        textA.gameObject.SetActive(playerA.transform.position.z < 1);
        textB.gameObject.SetActive(playerB.transform.position.z < 1);
        textBarrier.gameObject.SetActive((playerA.transform.position.z < barrier.transform.position.z &&
            playerA.transform.position.z > barrier.transform.position.z - 5) ||
            (playerB.transform.position.z < barrier.transform.position.z &&
            playerB.transform.position.z > barrier.transform.position.z - 5));
        textCoin.gameObject.SetActive(((playerA.transform.position.z < water.transform.position.z + 2 &&
            playerA.transform.position.z > water.transform.position.z - 5 ) ||
            (playerB.transform.position.z < water.transform.position.z + 2
            && playerB.transform.position.z > water.transform.position.z - 5))
            && textBarrier.gameObject.activeSelf == false);
        textColorZone.gameObject.SetActive(((playerA.transform.position.z < colorZone.transform.position.z &&
            playerA.transform.position.z > colorZone.transform.position.z - 8) ||
            (playerB.transform.position.z < colorZone.transform.position.z &&
            playerB.transform.position.z > colorZone.transform.position.z - 8))
            && textBarrier.gameObject.activeSelf == false);
        textEndGame.gameObject.SetActive(((playerA.transform.position.z < colorEndGame.transform.position.z &&
            playerA.transform.position.z > colorEndGame.transform.position.z - 15) ||
            (playerB.transform.position.z < colorEndGame.transform.position.z &&
            playerB.transform.position.z > colorEndGame.transform.position.z - 15)) && textCongrats.gameObject.activeSelf == false);
    }
}
