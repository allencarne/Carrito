using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPack : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite boostPackFull;
    [SerializeField] Sprite boostPackEmpty;

    [SerializeField] int boostAmount;
    [SerializeField] int boostPackCoolDown;
    bool isBoostPackReady;

    void Start()
    {
        isBoostPackReady = true;
        spriteRenderer.sprite = boostPackFull;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (collision.CompareTag("Car") && isBoostPackReady && player.currentBoost != player.maxBoost)
        {
            isBoostPackReady = false;
            spriteRenderer.sprite = boostPackEmpty;
            float boostToAdd = Mathf.Min(boostAmount, player.maxBoost - player.currentBoost);
            player.currentBoost += boostToAdd;

            StartCoroutine(BoostPackCoolDown());
        }
    }

    IEnumerator BoostPackCoolDown()
    {
        yield return new WaitForSeconds(boostPackCoolDown);

        isBoostPackReady = true;
        spriteRenderer.sprite = boostPackFull;
    }
}
