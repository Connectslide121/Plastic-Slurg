using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTextScript : MonoBehaviour
{
    public static int Health = 10;
    public Text HealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = "HEALTH: " + Health;


    }
}
