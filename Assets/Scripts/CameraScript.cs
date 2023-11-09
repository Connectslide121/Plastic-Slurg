using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Leo;
    public bool BossFight = false;
    public Vector3 BossFightCameraPosition;


    void Update()
    {
        if (Leo == null) return;
        
        if (BossFight == false)
        {
            FollowCharacter();
        }

        if (BossFight == true)
        {
            StopFollowingCharacter();
        }

    }

    public void FollowCharacter()
    {
        Vector3 position = transform.position;
        position.x = Leo.transform.position.x;
        transform.position = position;

    }

    public void StopFollowingCharacter()
    {
        transform.position = BossFightCameraPosition; 
    }

}

