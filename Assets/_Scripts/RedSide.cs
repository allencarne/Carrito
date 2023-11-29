using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSide : MonoBehaviour
{
    public bool redSide;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            redSide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            redSide = false;
        }
    }
}
