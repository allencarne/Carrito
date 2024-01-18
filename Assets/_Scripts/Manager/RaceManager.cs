using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoccerManager;

public class RaceManager : MonoBehaviour
{
    #region Singleton

    public static RaceManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than once instance of SoccerManager found!");
            return;
        }

        instance = this;
    }

    #endregion

    public bool CanMove = true;
}
