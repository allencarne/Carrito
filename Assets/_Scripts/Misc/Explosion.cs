using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] AudioSource goalExplosion;

    private void Awake()
    {
        goalExplosion.Play();
    }
}
