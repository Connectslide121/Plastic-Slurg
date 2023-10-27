using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class time : MonoBehaviour
{
    public Text frameRateText;
    public float updateRate = 1.0f; // How often to update the frame rate display

    private float nextUpdate = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate frame rate
        float currentFrameRate = 1.0f / Time.deltaTime;

        // Update the display every "updateRate" seconds
        if (Time.time > nextUpdate)
        {
            frameRateText.text = "FPS: " + Mathf.Round(currentFrameRate);
            nextUpdate = Time.time + updateRate;
        }
    }
}
