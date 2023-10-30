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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            AmmoTextScript.Ammo += AmmoToAdd;
            Instantiate(AmmoTakenPrefab, transform.position, Quaternion.identity);
            DestroyAmmo();
        }
    }

    public void DestroyAmmo()
    {
        Destroy(gameObject);
    }

}

