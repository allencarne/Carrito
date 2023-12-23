using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefsEditor : MonoBehaviour
{
    [MenuItem("Tools/Delete All PlayerPrefs")]
    private static void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("All PlayerPrefs deleted.");
    }
}
