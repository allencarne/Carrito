using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCycle : MonoBehaviour
{
    [SerializeField] float colorCycleSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] Color originalColor;

    private Image image;
    private float time;

    private void Start()
    {
        image = GetComponent<Image>();
        image.color = originalColor;
    }

    private void Update()
    {
        // Increment time based on colorCycleSpeed
        time += Time.deltaTime * colorCycleSpeed;

        // Calculate color based on time
        Color newColor = CalculateColor(time);

        // Update UI image color
        image.color = newColor;

        // Increment Z rotation based on rotationSpeed
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward, rotationAmount);
    }

    private Color CalculateColor(float t)
    {
        // Calculate normalized color values using sine function
        float r = Mathf.Sin(t) * 0.5f + 0.5f;
        float g = Mathf.Sin(t + 2f * Mathf.PI / 3f) * 0.5f + 0.5f;
        float b = Mathf.Sin(t + 4f * Mathf.PI / 3f) * 0.5f + 0.5f;

        // Combine color values
        return new Color(r, g, b, originalColor.a);
    }
}
