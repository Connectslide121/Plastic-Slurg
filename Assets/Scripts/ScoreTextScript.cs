using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public static int Score = 0;
    public Text ScoreText;

    void Update()
    {
        float totalScore = Score + AmmoTextScript.Ammo * 10 + HealthTextScript.Health * 50;
        ScoreText.text = "x " + totalScore;
    }
}
