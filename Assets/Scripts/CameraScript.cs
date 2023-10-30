using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Leo;


    void Update()
    {
        if (Leo == null) return;
        
        Vector3 position = transform.position;
        position.x = Leo.transform.position.x;
        transform.position = position;
    }
}
