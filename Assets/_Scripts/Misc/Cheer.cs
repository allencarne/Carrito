using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject cheerParticle;

    private void OnEnable()
    {
        Ball.OnScored += StartCheer;
    }

    private void OnDisable()
    {
        Ball.OnScored -= StartCheer;
    }

    void StartCheer()
    {
        animator.Play("Cheer");

        Instantiate(cheerParticle, transform.position, transform.rotation);

        StartCoroutine(ResetCheer());
    }

    IEnumerator ResetCheer()
    {
        yield return new WaitForSeconds(3);

        animator.Play("Idle");
    }
}
