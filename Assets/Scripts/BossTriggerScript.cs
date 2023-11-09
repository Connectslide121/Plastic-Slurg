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
            Boss.SetActive(true);
            Camera.GetComponent<CameraScript>().StopFollowingCharacter();
            Boss.GetComponent<BossIntroScript>().StopMainTheme();
            Camera.GetComponent <CameraScript>().BossFight = true;

        }
    }

}
