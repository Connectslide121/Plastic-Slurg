using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextScript : MonoBehaviour
{
    public static int Ammo;
    public Text AmmoText;

    void Update()
    {
        AmmoText.text = "x " + Ammo;
    }

}
