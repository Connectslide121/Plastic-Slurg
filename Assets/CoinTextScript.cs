using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinTextScript : MonoBehaviour
{
    public static int Coins = 0;
    public Text CoinsText;

    void Update()
    {
        CoinsText.text = "x " + Coins;
    }
}
