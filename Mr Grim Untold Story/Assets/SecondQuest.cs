using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondQuest : MonoBehaviour
{
    public GameManager gameManager;
    public GrimStat playerm;
    public int i;
    public Animation anim;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(playerm.soulCount >= 5)
            {
                anim.Play();
            }
        }
    }
}
