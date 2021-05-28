using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BubbleScript : MonoBehaviour
{

    private Text score;
    private float random;
    public GameObject bubbleLeft;
    public GameObject bubbleRight;
    public bool isLeft;
    public int balloonColorIndex = 0;
    private float bubbleOffset;
    private float bubbleHeight;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("GameCanvas/Score").GetComponent<Text>();
        bubbleHeight = Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y + 1.5f;
        bubbleOffset = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        random = Random.Range(-bubbleOffset , bubbleOffset);
        if (transform.localScale.x == 0.5f)
            transform.position = new Vector2(random, bubbleHeight);
        else if (isLeft)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 50.0f);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200.0f);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 50.0f);
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200.0f);
        }

        if (balloonColorIndex == 0)
        {
            random = Random.Range(1, 16);
            balloonColorIndex = (int)random;
        }
        
        this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(balloonColorIndex.ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.y < -4.0f)
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(this.GetComponent<Rigidbody2D>().velocity.x,-4.0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name.StartsWith("Laser"))
        {
            int currScore = int.Parse(score.text);
            score.text = (++currScore).ToString();
            if (this.transform.localScale.x > 0.25f)
            {
                Vector2 scale = this.transform.localScale;
                scale.x /= 2;
                scale.y /= 2;
                bubbleLeft.transform.localScale = new Vector2(scale.x, scale.y);
                bubbleRight.transform.localScale = new Vector2(scale.x, scale.y);
                Instantiate(bubbleLeft, new Vector2(this.transform.position.x - 0.5f, this.transform.position.y), Quaternion.identity);
                bubbleLeft.GetComponent<BubbleScript>().isLeft = true;
                bubbleLeft.GetComponent<BubbleScript>().balloonColorIndex = balloonColorIndex;
                Instantiate(bubbleRight, new Vector2(this.transform.position.x + 0.5f, this.transform.position.y), Quaternion.identity);
                bubbleRight.GetComponent<BubbleScript>().isLeft = false;
                bubbleLeft.GetComponent<BubbleScript>().balloonColorIndex = balloonColorIndex;
            }
        
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
