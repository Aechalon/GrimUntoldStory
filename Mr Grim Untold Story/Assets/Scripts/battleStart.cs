using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battleStart : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject BattleScene;
    public GameObject Main;
    public PlayerMovement playerMovement;

    public GrimDialogue grimDialogue;
   
    public WalkingAI ai;
 
    public void JustSpawn()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

    }
    public void Reference()
    {

        grimDialogue = GameObject.FindObjectOfType<GrimDialogue>();
        Main = GameObject.FindGameObjectWithTag("MainBattle");
        BattleScene = GameObject.FindGameObjectWithTag("MainCanvas");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            JustSpawn();
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (!gameManager.onBattle)
            {
                ai.isEnable = false;
                playerMovement.isControlEnb = false;
          
                Reference();
                grimDialogue.StartGame();
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ai.isEnable = true;
        }
    }
}
