using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostTakenScript : MonoBehaviour
{
    public AudioClip JumpBoostTaken;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(JumpBoostTaken);

    }

    public void DestroyJumpBoostTaken()
    {
        Destroy(gameObject);
    }
}
