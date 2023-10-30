using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTakenScript : MonoBehaviour
{
    public AudioClip take;

    private void Start()
    {
        Camera.main.GetComponent<AudioSource>().PlayOneShot(take);

    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }
}
