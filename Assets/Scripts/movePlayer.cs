using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    private float playerSpeed;
    public GameObject laserBullet;
    private float half_size;
    private Vector3 wrld;
    private int skipFrames;
    void Start()
    {
        skipFrames = 20;
        playerSpeed = 15.0f;
        transform.position = new Vector2(0,-4.0f);
        wrld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f));
        half_size = this.GetComponent<SpriteRenderer>().bounds.size.x / 4;
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -wrld.x + half_size)
            this.GetComponent<Rigidbody2D>().velocity = (Vector2.left * playerSpeed);
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < wrld.x - half_size)
            this.GetComponent<Rigidbody2D>().velocity = (Vector2.right * playerSpeed);
        else
            this.GetComponent<Rigidbody2D>().velocity = (Vector2.zero);

        //Tekli lazer atis
        /*
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 1.0f); 
            Instantiate(laserBullet, (Vector3) pos, Quaternion.identity);
        }
        */
         
        //Coklu lazer atis
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y + 1.0f);
            if (skipFrames > 0)
            {
                skipFrames--;
            }
            else
            {
                Instantiate(laserBullet, (Vector3)pos, Quaternion.identity);
                skipFrames = 25;
            }
            
        }

        foreach(GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.name == "LaserBullet(Clone)" && go.transform.position.y > 5.5f)
            {
               Destroy(go);
            }
        }

    }

    
}
