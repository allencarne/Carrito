using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Blue Goal"))
        {
            SceneManager.LoadScene(0);
        }

        if (collision.CompareTag("Red Goal"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
