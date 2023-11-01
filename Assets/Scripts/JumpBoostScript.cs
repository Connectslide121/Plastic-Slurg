using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostScript : MonoBehaviour
{
    public GameObject JumpBoostTakenPrefab;
    public float jumpForceBoost = 220;
    public GameObject JumpBoostEffectIcon;

    private LeoMovement leoMovement;
    private Coroutine boostCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            leoMovement = collision.gameObject.GetComponent<LeoMovement>();

            if (boostCoroutine != null)
            {
                StopCoroutine(boostCoroutine);
            }

            boostCoroutine = StartCoroutine(ApplyJumpForceBoost()); Instantiate(JumpBoostTakenPrefab, transform.position, Quaternion.identity);
        }
    }
    private IEnumerator ApplyJumpForceBoost()
    {
        leoMovement.JumpForce = jumpForceBoost;
        JumpBoostEffectIcon.SetActive(true);

        yield return new WaitForSeconds(3f);

        leoMovement.JumpForce = 150;
        JumpBoostEffectIcon.SetActive(false);

        boostCoroutine = null;
    }
}
