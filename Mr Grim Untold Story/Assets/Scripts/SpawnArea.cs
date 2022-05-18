using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    // Start is called before the first frame 
    public WalkingAI ai;
    public int d;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // up 1 down 2 left 3 right 4
            ai.direction = d;
            Debug.Log("should");    
        }
    }
}
