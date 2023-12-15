using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    [SerializeField] CarOptions blueOptions;
    [SerializeField] CarOptions redOptions;

    [SerializeField] SpriteRenderer body;
    [SerializeField] SpriteRenderer tire;
    [SerializeField] SpriteRenderer wing;
    [SerializeField] TrailRenderer trail;

    public enum TeamType
    {
        None,
        Blue,
        Red
    }

    public TeamType team = TeamType.None;

    private void Start()
    {
        // Select random options based on the team type
        if (team == TeamType.Blue)
        {
            SelectRandomOptions(blueOptions);
        }
        else if (team == TeamType.Red)
        {
            SelectRandomOptions(redOptions);
        }
    }

    private void SelectRandomOptions(CarOptions options)
    {
        // Body
        if (options.bodys.Length > 0)
            body.sprite = options.bodys[Random.Range(0, options.bodys.Length)];

        // Tire
        if (options.tires.Length > 0)
            tire.sprite = options.tires[Random.Range(0, options.tires.Length)];

        // Wing
        if (options.wings.Length > 0)
            wing.sprite = options.wings[Random.Range(0, options.wings.Length)];

        // Paint
        if (options.paint.Length > 0)
            body.color = options.paint[Random.Range(0, options.paint.Length)];

        // Trail
        if (options.trails.Length > 0)
            trail.colorGradient = options.trails[Random.Range(0, options.trails.Length)];
    }
}
