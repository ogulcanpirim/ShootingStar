using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSpawner : MonoBehaviour
{
    public GameObject bubble;

    void Start()
    {
       StartCoroutine(waitBubble());
    }

    void Update()
    {
        foreach(GameObject go in GameObject.FindObjectsOfType<GameObject>())
        {
            if (go.name.StartsWith("bubble") && (go.transform.position.y < -5.5f))
            {         
                Destroy(go);    
            }
        }
    }
    IEnumerator waitBubble()
    {
        yield return new WaitForSeconds(1);
        Instantiate(bubble);
        StartCoroutine(waitBubble());
    }
}
