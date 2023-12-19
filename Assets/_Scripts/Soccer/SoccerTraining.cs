using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerTraining : MonoBehaviour
{
    public GameObject trainingPanel;

    [Header("Car")]
    public Transform carTransform;

    [Header("Ball")]
    public Transform ballTransform;
    //public float ballSpeed;

    [Header("Striker 1")]
    public Transform striker1;
    public Transform striker1Ball;

    [Header("Striker 2")]
    Vector3 striker2Position;
    Quaternion striker2Rotation;

    [Header("Striker 3")] Vector3 striker3Position;
    Quaternion striker3Rotation;

    [Header("Striker 4")] Vector3 striker4Position;
    Quaternion striker4Rotation;

    Vector3 ball4Position;
    Vector2 ball4direction;
    float ball4Speed;

    [Header("Striker 5")] Vector3 striker5Position;
    Quaternion striker5Rotation;

    Vector3 ball5Position;
    Vector2 ball5direction;
    float ball5Speed;

    [Header("Striker 6")] 
    Vector3 striker6Position;
    Quaternion striker6Rotation;

    Vector3 ball6Position;
    Vector2 ball6direction;
    float ball6Speed;

    [Header("Striker 7")]
    Vector3 striker7Position;
    Quaternion striker7Rotation;

    Vector3 ball7Position;
    Vector2 ball7direction;
    float ball7Speed;

    [Header("Striker 8")]
    Vector3 striker8Position;
    Quaternion striker8Rotation;

    Vector3 ball8Position;
    Vector2 ball8direction;
    float ball8Speed;

    [Header("Striker 9")]
    Vector3 striker9Position;
    Quaternion striker9Rotation;

    Vector3 ball9Position;
    Vector2 ball9direction;
    float ball9Speed;

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
    }

    public Training training = Training.None;

    enum TrainingState
    {
        Selection,
        CountDown,
        Playing,
        Paused,
        GoalScored,
    }

    TrainingState state = TrainingState.Selection;


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
        }

        switch (state)
        {
            case TrainingState.Selection:
                Selection();
                break;
            case TrainingState.CountDown:
                break;
            case TrainingState.Playing:
                break;
            case TrainingState.Paused:
                break;
            case TrainingState.GoalScored:
                break;
        }
    }

    void Selection()
    {

    }

    void CountDown()
    {

    }

    void Playing()
    {

    }

    void Paused()
    {

    }

    void GoalScored()
    {

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

    }

    public void Striker5()
    {

    }

    public void Striker6()
    {

    }

    public void Striker7()
    {

    }

    public void Striker8()
    {

    }

    public void Striker9()
    {

    }

    public void Striker10()
    {

    }
}
