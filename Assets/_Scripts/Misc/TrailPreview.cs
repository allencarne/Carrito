using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPreview : MonoBehaviour
{
    public ParticleSystem trailParcile;
    public float newGravityModifier;

    void Start()
    {
        if (trailParcile == null)
        {
            // If the ParticleSystem reference is not set in the Inspector, try to get it from the GameObject
            trailParcile = GetComponent<ParticleSystem>();
        }

        if (trailParcile != null)
        {
            ModifyGravityModifier();
        }
        else
        {
            Debug.LogError("Particle System not found or ParticleSystem component not attached.");
        }
    }

    void ModifyGravityModifier()
    {
        // Access the main module of the ParticleSystem
        var mainModule = trailParcile.main;

        // Modify the gravityModifier property
        mainModule.gravityModifier = newGravityModifier;
    }
}
