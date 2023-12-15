using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Customization/Car")]
public class CarOptions : ScriptableObject
{
    public Sprite[] bodys;
    public Sprite[] tires;
    public Sprite[] wings;

    public Color[] paint;

    public GameObject[] trails;
}
