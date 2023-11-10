using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTakenScript : MonoBehaviour
{

    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayHeartTaken();
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
