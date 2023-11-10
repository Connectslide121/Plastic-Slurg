using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriggerScript : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject Music = GameObject.FindGameObjectWithTag("Music");
            Music.GetComponent<MusicManagerScript>().StopMainTheme();


            Boss.SetActive(true);
            Camera.GetComponent<CameraScript>().StopFollowingCharacter();
            Camera.GetComponent <CameraScript>().BossFight = true;

        }
    }

}
