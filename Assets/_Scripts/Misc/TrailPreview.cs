using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailPreview : MonoBehaviour
{
    public ParticleSystem trailParticle;
    public float newGravityModifier;

    void Start()
    {
        if (trailParticle == null)
        {
            // If the ParticleSystem reference is not set in the Inspector, try to get it from the GameObject
            trailParticle = GetComponent<ParticleSystem>();
        }

        if (trailParticle != null)
        {
            // Make the Particle System play on awake
            var mainModule = trailParticle.main;
            mainModule.playOnAwake = true;

            // Modify the gravityModifier property
            mainModule.gravityModifier = newGravityModifier;

            // Start playing the Particle System
            trailParticle.Play();
        }
        else
        {
            Debug.LogError("Particle System not found or ParticleSystem component not attached.");
        }
    }
}
