using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerTraining : MonoBehaviour
{
    [SerializeField] GameObject trainingPanel;

    public enum Training 
    { 
        None,
        Striker1,
        Striker2,
        Striker3,
    }

    public Training training = Training.None;

    private void Start()
    {
        //trainingPanel.SetActive(true);
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
