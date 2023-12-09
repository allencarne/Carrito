using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoostPack : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite boostPackFull;
    [SerializeField] Sprite boostPackEmpty;
    [SerializeField] GameObject smallCircleFX;

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
        var soccerAI = collision.gameObject.GetComponent<SoccerAI>();

        if (collision.CompareTag("Car") && isBoostPackReady)
        {
            if (player != null && player.currentBoost != player.maxBoost)
            {
                Instantiate(smallCircleFX, transform.position, transform.rotation);

                isBoostPackReady = false;
                spriteRenderer.sprite = boostPackEmpty;
                float boostToAdd = Mathf.Min(boostAmount, player.maxBoost - player.currentBoost);
                player.currentBoost += boostToAdd;

                StartCoroutine(BoostPackCoolDown());
            }

            if (soccerAI != null && soccerAI.currentBoost != soccerAI.maxBoost)
            {
                Instantiate(smallCircleFX, transform.position, transform.rotation);

                isBoostPackReady = false;
                spriteRenderer.sprite = boostPackEmpty;
                float boostToAdd = Mathf.Min(boostAmount, soccerAI.maxBoost - soccerAI.currentBoost);
                soccerAI.currentBoost += boostToAdd;

                StartCoroutine(BoostPackCoolDown());
            }
        }

        /*
        if (collision.CompareTag("Car") && isBoostPackReady && player.currentBoost != player.maxBoost)
        {
            Instantiate(smallCircleFX, transform.position, transform.rotation);

            isBoostPackReady = false;
            spriteRenderer.sprite = boostPackEmpty;
            float boostToAdd = Mathf.Min(boostAmount, player.maxBoost - player.currentBoost);
            player.currentBoost += boostToAdd;

            StartCoroutine(BoostPackCoolDown());
        }
        */
    }

    IEnumerator BoostPackCoolDown()
    {
        yield return new WaitForSeconds(boostPackCoolDown);

        isBoostPackReady = true;
        spriteRenderer.sprite = boostPackFull;
    }
}
