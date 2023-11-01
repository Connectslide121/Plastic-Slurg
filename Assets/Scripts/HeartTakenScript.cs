using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTakenScript : MonoBehaviour
{
    public AudioClip HeartTaken;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(HeartTaken);

    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
