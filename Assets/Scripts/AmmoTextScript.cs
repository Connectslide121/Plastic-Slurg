using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextScript : MonoBehaviour
{
    public static int Ammo;
    public Text AmmoText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = "AMMO: " + Ammo;

    }

}
