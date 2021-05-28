using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnBalls : MonoBehaviour
{

    private GameObject[] balls;
    private float screenWidth;
    private float screenHeight;
    void Start()
    {
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        balls = new GameObject[transform.childCount];
        
        for (int i = 0; i < transform.childCount; i ++)
        {
            balls[i] = transform.GetChild(i).gameObject;
        }

    }

    void Update()
    {

        for (int i = 0; i < transform.childCount; i++)
        {
            if (balls[i].transform.position.y < -10.0f)
            {
                balls[i].transform.position = new Vector3(Random.Range(-screenWidth, screenWidth), Random.Range(screenHeight, screenHeight * 2), 0);
                balls[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }

    }

    public void changeGame()
    {
        SceneManager.LoadScene(1);
    }

    
}
