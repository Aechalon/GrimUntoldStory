using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClaimBottle : MonoBehaviour
{
    public int i;
    public GrimStat grim;
    public void Start()
    {
        grim = GameObject.FindObjectOfType<GrimStat>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            
            switch (i)
            {
                case 1:
                    grim.hpPot += 5;
                    Destroy(this.gameObject);
                    break;
                case 2:
                    grim.mpPot += 5;
                    Destroy(this.gameObject);
                    break;


            }
        }
    }
}
