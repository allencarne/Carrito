using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SoccerTraining : MonoBehaviour
{
    [SerializeField] GameObject striker1Button;
    public GameObject trainingPanel;

    public bool isStriker;

    [Header("Car")]
    public Transform carTransform;

    [Header("Ball")]
    public Transform ballTransform;

    [Header("Striker 1")]
    [SerializeField] Image striker1bubble;
    public Transform striker1;
    public Transform striker1Ball;

    [Header("Striker 2")]
    [SerializeField] Image striker2bubble;
    public Transform striker2;
    public Transform striker2Ball;

    [Header("Striker 3")]
    [SerializeField] Image striker3bubble;
    public Transform striker3;
    public Transform striker3Ball;

    [Header("Striker 4")]
    [SerializeField] Image striker4bubble;
    public Transform striker4;
    public Transform striker4Ball;

    [Header("Striker 5")]
    [SerializeField] Image striker5bubble;
    public Transform striker5;
    public Transform striker5Ball;

    [Header("Striker 6")]
    [SerializeField] Image striker6bubble;
    public Transform striker6;
    public Transform striker6Ball;

    [Header("Striker 7")]
    [SerializeField] Image striker7bubble;
    public Transform striker7;
    public Transform striker7Ball;

    [Header("Striker 8")]
    [SerializeField] Image striker8bubble;
    public Transform striker8;
    public Transform striker8Ball;

    [Header("Striker 9")]
    [SerializeField] Image striker9bubble;
    public Transform striker9;
    public Transform striker9Ball;

    [Header("Striker 10")]
    [SerializeField] Image striker10bubble;
    public Transform striker10;
    public Transform striker10Ball;

    [Header("Defender 1")]
    [SerializeField] Image defender1bubble;
    public Transform defender1;
    public Transform defender1Ball;

    [Header("Defender 2")]
    [SerializeField] Image defender2bubble;
    public Transform defender2;
    public Transform defender2Ball;

    [Header("Defender 3")]
    [SerializeField] Image defender3bubble;
    public Transform defender3;
    public Transform defender3Ball;

    [Header("Defender 4")]
    [SerializeField] Image defender4bubble;
    public Transform defender4;
    public Transform defender4Ball;

    [Header("Defender 5")]
    [SerializeField] Image defender5bubble;
    public Transform defender5;
    public Transform defender5Ball;

    [Header("Defender 6")]
    [SerializeField] Image defender6bubble;
    public Transform defender6;
    public Transform defender6Ball;

    [Header("Defender 7")]
    [SerializeField] Image defender7bubble;
    public Transform defender7;
    public Transform defender7Ball;

    [Header("Defender 8")]
    [SerializeField] Image defender8bubble;
    public Transform defender8;
    public Transform defender8Ball;

    [Header("Defender 9")]
    [SerializeField] Image defender9bubble;
    public Transform defender9;
    public Transform defender9Ball;

    [Header("Defender 10")]
    [SerializeField] Image defender10bubble;
    public Transform defender10;
    public Transform defender10Ball;

    public enum Training 
    { 
        None,
        Striker1,
        Striker2,
        Striker3,
        Striker4,
        Striker5,
        Striker6,
        Striker7,
        Striker8,
        Striker9,
        Striker10,
        Defender1,
        Defender2,
        Defender3,
        Defender4,
        Defender5,
        Defender6,
        Defender7,
        Defender8,
        Defender9,
        Defender10,
    }

    public Training training = Training.None;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        if (SoccerManager.instance.gameMode == SoccerManager.GameMode.Training)
        {
            EventSystem.current.SetSelectedGameObject(striker1Button);
        }


        if (PlayerPrefs.GetInt("Striker1") == 1)
        {
            striker1bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker2") == 1)
        {
            striker2bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker3") == 1)
        {
            striker3bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker4") == 1)
        {
            striker4bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker5") == 1)
        {
            striker5bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker6") == 1)
        {
            striker6bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker7") == 1)
        {
            striker7bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker8") == 1)
        {
            striker8bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker9") == 1)
        {
            striker9bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Striker10") == 1)
        {
            striker10bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender1") == 1)
        {
            defender1bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender2") == 1)
        {
            defender2bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender3") == 1)
        {
            defender3bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender4") == 1)
        {
            defender4bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender5") == 1)
        {
            defender5bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender6") == 1)
        {
            defender6bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender7") == 1)
        {
            defender7bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender8") == 1)
        {
            defender8bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender9") == 1)
        {
            defender9bubble.color = Color.green;
        }

        if (PlayerPrefs.GetInt("Defender10") == 1)
        {
            defender10bubble.color = Color.green;
        }





        if (PlayerPrefs.GetInt("ResetS1") == 1)
        {
            Striker1();
        }

        if (PlayerPrefs.GetInt("ResetS2") == 1)
        {
            Striker2();
        }

        if (PlayerPrefs.GetInt("ResetS3") == 1)
        {
            Striker3();
        }

        if (PlayerPrefs.GetInt("ResetS4") == 1)
        {
            Striker4();
        }

        if (PlayerPrefs.GetInt("ResetS5") == 1)
        {
            Striker5();
        }

        if (PlayerPrefs.GetInt("ResetS6") == 1)
        {
            Striker6();
        }

        if (PlayerPrefs.GetInt("ResetS7") == 1)
        {
            Striker7();
        }

        if (PlayerPrefs.GetInt("ResetS8") == 1)
        {
            Striker8();
        }

        if (PlayerPrefs.GetInt("ResetS9") == 1)
        {
            Striker9();
        }

        if (PlayerPrefs.GetInt("ResetS10") == 1)
        {
            Striker10();
        }

        if (PlayerPrefs.GetInt("ResetD1") == 1)
        {
            Defender1();
        }

        if (PlayerPrefs.GetInt("ResetD2") == 1)
        {
            Defender2();
        }

        if (PlayerPrefs.GetInt("ResetD3") == 1)
        {
            Defender3();
        }

        if (PlayerPrefs.GetInt("ResetD4") == 1)
        {
            Defender4();
        }

        if (PlayerPrefs.GetInt("ResetD5") == 1)
        {
            Defender5();
        }

        if (PlayerPrefs.GetInt("ResetD6") == 1)
        {
            Defender6();
        }

        if (PlayerPrefs.GetInt("ResetD7") == 1)
        {
            Defender7();
        }

        if (PlayerPrefs.GetInt("ResetD8") == 1)
        {
            Defender8();
        }

        if (PlayerPrefs.GetInt("ResetD9") == 1)
        {
            Defender9();
        }

        if (PlayerPrefs.GetInt("ResetD10") == 1)
        {
            Defender10();
        }
    }

    public void Striker1()
    {
        training = Training.Striker1;
        isStriker = true;
    }

    public void Striker2()
    {
        training = Training.Striker2;
        isStriker = true;
    }

    public void Striker3()
    {
        training = Training.Striker3;
        isStriker = true;
    }

    public void Striker4()
    {
        training = Training.Striker4;
        isStriker = true;
    }

    public void Striker5()
    {
        training = Training.Striker5;
        isStriker = true;
    }

    public void Striker6()
    {
        training = Training.Striker6;
        isStriker = true;
    }

    public void Striker7()
    {
        training = Training.Striker7;
        isStriker = true;
    }

    public void Striker8()
    {
        training = Training.Striker8;
        isStriker = true;
    }

    public void Striker9()
    {
        training = Training.Striker9;
        isStriker = true;
    }

    public void Striker10()
    {
        training = Training.Striker10;
        isStriker = true;
    }

    public void Defender1()
    {
        training = Training.Defender1;
        isStriker = false;
    }

    public void Defender2()
    {
        training = Training.Defender2;
        isStriker = false;
    }

    public void Defender3()
    {
        training = Training.Defender3;
        isStriker = false;
    }

    public void Defender4()
    {
        training = Training.Defender4;
        isStriker = false;
    }

    public void Defender5()
    {
        training = Training.Defender5;
        isStriker = false;
    }

    public void Defender6()
    {
        training = Training.Defender6;
        isStriker = false;
    }

    public void Defender7()
    {
        training = Training.Defender7;
        isStriker = false;
    }

    public void Defender8()
    {
        training = Training.Defender8;
        isStriker = false;
    }

    public void Defender9()
    {
        training = Training.Defender9;
        isStriker = false;
    }

    public void Defender10()
    {
        training = Training.Defender10;
        isStriker = false;
    }

    public void ResetState()
    {
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

    public void ReloadTrainingLevel()
    {
        switch (training)
        {
            case Training.Striker1:

                PlayerPrefs.SetInt("ResetS1", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker2:

                PlayerPrefs.SetInt("ResetS2", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker3:

                PlayerPrefs.SetInt("ResetS3", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker4:

                PlayerPrefs.SetInt("ResetS4", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker5:

                PlayerPrefs.SetInt("ResetS5", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker6:

                PlayerPrefs.SetInt("ResetS6", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker7:

                PlayerPrefs.SetInt("ResetS7", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker8:

                PlayerPrefs.SetInt("ResetS8", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker9:

                PlayerPrefs.SetInt("ResetS9", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Striker10:

                PlayerPrefs.SetInt("ResetS10", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender1:

                PlayerPrefs.SetInt("ResetD1", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender2:

                PlayerPrefs.SetInt("ResetD2", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender3:

                PlayerPrefs.SetInt("ResetD3", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender4:

                PlayerPrefs.SetInt("ResetD4", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender5:

                PlayerPrefs.SetInt("ResetD5", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender6:

                PlayerPrefs.SetInt("ResetD6", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender7:

                PlayerPrefs.SetInt("ResetD7", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender8:

                PlayerPrefs.SetInt("ResetD8", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender9:

                PlayerPrefs.SetInt("ResetD9", 1);
                SceneManager.LoadScene("Soccer");

                break;
            case Training.Defender10:

                PlayerPrefs.SetInt("ResetD10", 1);
                SceneManager.LoadScene("Soccer");

                break;
        }
    }

    public void UpdateBubble()
    {
        switch (training)
        {
            case Training.Striker1:
                PlayerPrefs.SetInt("Striker1", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker2:
                PlayerPrefs.SetInt("Striker2", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker3:
                PlayerPrefs.SetInt("Striker3", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker4:
                PlayerPrefs.SetInt("Striker4", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker5:
                PlayerPrefs.SetInt("Striker5", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker6:
                PlayerPrefs.SetInt("Striker6", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker7:
                PlayerPrefs.SetInt("Striker7", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker8:
                PlayerPrefs.SetInt("Striker8", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker9:
                PlayerPrefs.SetInt("Striker9", 1);
                PlayerPrefs.Save();
                break;
            case Training.Striker10:
                PlayerPrefs.SetInt("Striker10", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender1:
                PlayerPrefs.SetInt("Defender1", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender2:
                PlayerPrefs.SetInt("Defender2", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender3:
                PlayerPrefs.SetInt("Defender3", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender4:
                PlayerPrefs.SetInt("Defender4", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender5:
                PlayerPrefs.SetInt("Defender5", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender6:
                PlayerPrefs.SetInt("Defender6", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender7:
                PlayerPrefs.SetInt("Defender7", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender8:
                PlayerPrefs.SetInt("Defender8", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender9:
                PlayerPrefs.SetInt("Defender9", 1);
                PlayerPrefs.Save();
                break;
            case Training.Defender10:
                PlayerPrefs.SetInt("Defender10", 1);
                PlayerPrefs.Save();
                break;
        }
    }
}
