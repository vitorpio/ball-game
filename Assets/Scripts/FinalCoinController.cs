using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class FinalCoinController : CoinController
{

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && score.canGetFinalCoin)
        {
            SceneManager.LoadScene("EndGame");
        }
    }
}
