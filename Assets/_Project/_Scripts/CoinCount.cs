using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinCount : MonoBehaviour
{

    public Text coin;
    public Text coinsCountText;
    int count = 0;



    void Update()
    {
        coin.text = count.ToString();
        coinsCountText.text = "Coins: " + count.ToString();
    }

    public void AddCount()
    {
        count++;
    }
}
