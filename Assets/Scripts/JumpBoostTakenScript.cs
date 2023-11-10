using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostTakenScript : MonoBehaviour
{

    private void Start()
    {
        GameObject SFX = GameObject.FindGameObjectWithTag("SFX");
        SFX.GetComponent<SFXManagerScript>().PlayJumpBoostTaken();
    }

    public void DestroyJumpBoostTaken()
    {
        Destroy(gameObject);
    }
}
