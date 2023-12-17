using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowAndZoom : MonoBehaviour
{
    public Transform target;
    public float zoomSpeed = 5f;
    public float maxZoom = 10f;
    bool canFollow;

    private float originalZoom;
    private Vector3 originalPosition;

    private void OnEnable()
    {
        Ball.OnScored += SomeoneScored;
    }

    private void OnDisable()
    {
        Ball.OnScored -= SomeoneScored;
    }

    private void Start()
    {
        // Store the original camera parameters
        originalZoom = Camera.main.orthographicSize;
        originalPosition = Camera.main.transform.position;
    }

    private void Update()
    {
        if (target != null && canFollow)
        {
            // Smoothly move to the player's position
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, -10);
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, targetPosition, Time.deltaTime * zoomSpeed);

            // Slowly zoom in
            float targetZoom = Mathf.MoveTowards(Camera.main.orthographicSize, maxZoom, Time.deltaTime * zoomSpeed);
            Camera.main.orthographicSize = targetZoom;
        }
    }

    public void SomeoneScored()
    {
        canFollow = true;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(3);

        ResetCamera();
    }

    private void ResetCamera()
    {
        canFollow = false;

        // Reset camera parameters to their original values
        Camera.main.orthographicSize = originalZoom;
        Camera.main.transform.position = originalPosition;
    }
}
