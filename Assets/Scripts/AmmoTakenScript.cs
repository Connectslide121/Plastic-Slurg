using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTakenScript : MonoBehaviour
{

    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayAmmoTaken();
    }

    public void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
