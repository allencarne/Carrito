using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoccerTraining : MonoBehaviour
{
    public GameObject trainingPanel;

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
    public Vector2 ball5direction;
    public float ball5Speed;

    [Header("Striker 6")]
    [SerializeField] Image striker6bubble;

    public Transform striker6;
    public Transform striker6Ball;
    public Vector2 ball6direction;
    public float ball6Speed;

    [Header("Striker 7")]
    [SerializeField] Image striker7bubble;

    public Transform striker7;
    public Transform striker7Ball;
    public Vector2 ball7direction;
    public float ball7Speed;

    [Header("Striker 8")]
    [SerializeField] Image striker8bubble;

    public Transform striker8;
    public Transform striker8Ball;
    public Vector2 ball8direction;
    public float ball8Speed;

    [Header("Striker 9")]
    [SerializeField] Image striker9bubble;

    public Transform striker9;
    public Transform striker9Ball;
    public Vector2 ball9direction;
    public float ball9Speed;

    [Header("Striker 10")]
    [SerializeField] Image striker10bubble;

    public Transform striker10;
    public Transform striker10Ball;
    public Vector2 ball10direction;
    public float ball10Speed;

    [Header("Defender 1")]
    Vector3 defender1position;
    Quaternion defender1Rotation;

    Vector3 dBall1Position;
    Vector2 dBall1direction;
    float dBall1Speed;

    [Header("Defender 2")]
    Vector3 defender2position;
    Quaternion defender2Rotation;

    Vector3 dBall2Position;
    Vector2 dBall2direction;
    float dBall2Speed;

    [Header("Defender 3")]
    Vector3 defender3position;
    Quaternion defender3Rotation;

    Vector3 dBall3Position;
    Vector2 dBall3direction;
    float dBall3Speed;

    [Header("Defender 4")]
    Vector3 defender4position;
    Quaternion defender4Rotation;

    Vector3 dBall4Position;
    Vector2 dBall4direction;
    float dBall4Speed;

    [Header("Defender 5")]
    Vector3 defender5position;
    Quaternion defender5Rotation;

    Vector3 dBall5Position;
    Vector2 dBall5direction;
    float dBall5Speed;

    [Header("Defender 6")]
    Vector3 defender6position;
    Quaternion defender6Rotation;

    Vector3 dBall6Position;
    Vector2 dBall6direction;
    float dBall6Speed;

    [Header("Defender 7")]
    Vector3 defender7position;
    Quaternion defender7Rotation;

    Vector3 dBall7Position;
    Vector2 dBall7direction;
    float dBall7Speed;

    [Header("Defender 8")]
    Vector3 defender8position;
    Quaternion defender8Rotation;

    Vector3 dBall8Position;
    Vector2 dBall8direction;
    float dBall8Speed;

    [Header("Defender 9")]
    Vector3 defender9position;
    Quaternion defender9Rotation;

    Vector3 dBall9Position;
    Vector2 dBall9direction;
    float dBall9Speed;

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
        if (PlayerPrefs.GetInt("Striker1") == 1)
        {
            striker1bubble.color = Color.green;
        }
    }


    private void Update()
    {
        switch (training)
        {
            case Training.Striker1:
                break;
            case Training.Striker2:
                break;
            case Training.Striker3:
                break;
            case Training.Striker4:
                break;
            case Training.Striker5:
                break;
            case Training.Striker6:
                break;
            case Training.Striker7:
                break;
            case Training.Striker8:
                break;
            case Training.Striker9:
                break;
            case Training.Striker10:
                break;
            case Training.Defender1:
                break;
            case Training.Defender2:
                break;
            case Training.Defender3:
                break;
            case Training.Defender4:
                break;
            case Training.Defender5:
                break;
            case Training.Defender6:
                break;
            case Training.Defender7:
                break;
            case Training.Defender8:
                break;
            case Training.Defender9:
                break;
            case Training.Defender10:
                break;
        }
    }

    public void Striker1()
    {
        training = Training.Striker1;
    }

    public void Striker2()
    {
        training = Training.Striker2;
    }

    public void Striker3()
    {
        training = Training.Striker3;
    }

    public void Striker4()
    {
        training = Training.Striker4;
    }

    public void Striker5()
    {
        training = Training.Striker5;
    }

    public void Striker6()
    {
        training = Training.Striker6;
    }

    public void Striker7()
    {
        training = Training.Striker7;
    }

    public void Striker8()
    {
        training = Training.Striker8;
    }

    public void Striker9()
    {
        training = Training.Striker9;
    }

    public void Striker10()
    {
        training = Training.Striker10;
    }

    public void Defender1()
    {
        training = Training.Defender1;
    }

    public void Defender2()
    {
        training = Training.Defender2;
    }

    public void Defender3()
    {
        training = Training.Defender3;
    }

    public void Defender4()
    {
        training = Training.Defender4;
    }

    public void Defender5()
    {
        training = Training.Defender5;
    }

    public void Defender6()
    {
        training = Training.Defender6;
    }

    public void Defender7()
    {
        training = Training.Defender7;
    }

    public void Defender8()
    {
        training = Training.Defender8;
    }

    public void Defender9()
    {
        training = Training.Defender9;
    }

    public void Defender10()
    {
        training = Training.Defender10;
    }
}
