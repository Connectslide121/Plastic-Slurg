using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{
    public static int Health = 10;
    public Text HealthText;

    void Update()
    {
        HealthText.text = "x " + Health;
    }
}
