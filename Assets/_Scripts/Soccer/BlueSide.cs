using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSide : MonoBehaviour
{
    public bool blueSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            blueSide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            blueSide = false;
        }
    }
}
