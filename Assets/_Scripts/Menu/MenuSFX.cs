using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField] AudioSource menuHover;
    [SerializeField] AudioSource menuSelect;

    public void MenuHover()
    {
        menuHover.Play();
    }

    public void MenuSelect()
    {
        menuSelect.Play();
    }
}
