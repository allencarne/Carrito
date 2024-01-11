using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioSource menuHover;
    [SerializeField] AudioSource menuSelect;

    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        // Reset the PlayerPrefs for tracking Current Training
        PlayerPrefs.SetInt("ResetS1", 0);
        PlayerPrefs.SetInt("ResetS2", 0);
        PlayerPrefs.SetInt("ResetS3", 0);
        PlayerPrefs.SetInt("ResetS4", 0);
        PlayerPrefs.SetInt("ResetS5", 0);
        PlayerPrefs.SetInt("ResetS6", 0);
        PlayerPrefs.SetInt("ResetS7", 0);
        PlayerPrefs.SetInt("ResetS8", 0);
        PlayerPrefs.SetInt("ResetS9", 0);
        PlayerPrefs.SetInt("ResetS10", 0);
        PlayerPrefs.SetInt("ResetD1", 0);
        PlayerPrefs.SetInt("ResetD2", 0);
        PlayerPrefs.SetInt("ResetD3", 0);
        PlayerPrefs.SetInt("ResetD4", 0);
        PlayerPrefs.SetInt("ResetD5", 0);
        PlayerPrefs.SetInt("ResetD6", 0);
        PlayerPrefs.SetInt("ResetD7", 0);
        PlayerPrefs.SetInt("ResetD8", 0);
        PlayerPrefs.SetInt("ResetD9", 0);
        PlayerPrefs.SetInt("ResetD10", 0);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // This method will be called when a new scene has finished loading
        // (Optional: You can put any post-loading logic here)
    }

    public void SoccerButton()
    {
        StartCoroutine(MenuDelay("SoccerMenu"));
    }

    public void RaceButton()
    {
        StartCoroutine(MenuDelay("RaceMenu"));
    }

    public void BattleButton()
    {
        StartCoroutine(MenuDelay("BattleMenu"));
    }

    public void OptionsButton()
    {
        StartCoroutine(MenuDelay("OptionsMenu"));
    }

    public void BindsButton()
    {
        StartCoroutine(MenuDelay("BindsMenu"));
    }

    IEnumerator MenuDelay(string ButtonName)
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay time as needed

        SceneManager.LoadScene(ButtonName);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void MenuHover()
    {
        menuHover.Play();
    }

    public void MenuSelect()
    {
        menuSelect.Play();
    }
}
