using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGot : MonoBehaviour
{
    public GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        gameManager.GodKey = true;
    }

}
