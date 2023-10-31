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
        ScoreText.text = "x " + Score;
    }
}
