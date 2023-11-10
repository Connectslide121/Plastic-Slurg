using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public static int Score = 0;
    public TextMeshProUGUI ScoreText;

    void Update()
    {
        float totalScore = Score + AmmoTextScript.Ammo * 10 + HealthTextScript.Health * 50 + CoinTextScript.Coins * 10;
        ScoreText.text = "" + totalScore;
    }
}
