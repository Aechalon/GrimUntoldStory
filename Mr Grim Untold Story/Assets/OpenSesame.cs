using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSesame : MonoBehaviour
{
    public GameManager gameManager;
    public Animation anim;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (gameManager.GodKey)
            {
                anim.Play();

                gameManager.GodKey = false;
            }
        }
    }
}
