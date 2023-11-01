using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AmmoScript : MonoBehaviour
{
    public int AmmoToAdd = 50;
    public GameObject AmmoTakenPrefab;

       
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AmmoTextScript.Ammo += AmmoToAdd;
        Instantiate(AmmoTakenPrefab, transform.position, Quaternion.identity);
        DestroyAmmo();
    }

    public void DestroyAmmo()
    {
        Destroy(gameObject);
    }

}

