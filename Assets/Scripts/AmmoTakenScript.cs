using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTakenScript : MonoBehaviour
{
    public AudioClip explode;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(explode);

    }

    public void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
