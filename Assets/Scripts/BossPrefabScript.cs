using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPrefabScript : MonoBehaviour
{
    public GameObject BossDeathPrefab;
    public GameObject BossDeathExplosionPrefab;

    private void Start()
    {
        

    }

    public void BossPrefabSpawn()
    {
        Instantiate(BossDeathPrefab, transform.position, Quaternion.identity);
        Instantiate(BossDeathExplosionPrefab, transform.position, Quaternion.identity);
    }

}
