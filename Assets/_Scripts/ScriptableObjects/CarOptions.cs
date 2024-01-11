using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Car")]
public class CarOptions : ScriptableObject
{
    public Sprite[] bodys;
    public Sprite[] lights;
    public Sprite[] tires;
    public Sprite[] wings;

    public Color[] paint;

    //Trail
    public ParticleSystem[] trails;
    public Gradient[] trailColor;

    // Explosion
    public GameObject[] explosions;
}
