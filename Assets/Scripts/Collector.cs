using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Collector : MonoBehaviour
{

    int coin = 0;


   void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Coin")
        {
            SetCoin();
            GameManager.instance.CoinGrabbed(other.gameObject, coin);
        }
    }

     void SetCoin()
    {
        coin++;
    }


}
