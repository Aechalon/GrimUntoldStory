using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearTheGod : MonoBehaviour
{
    public GameManager gameManager;
    public NpcSoul npc;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.questTracker = 3;
            gameManager.finalQuest = true;
            npc.QuestPopUp();
            Invoke("delayInactive", 3f);
        }
    }
 
    public void delayInactive()
    {
        this.gameObject.SetActive(false);
    }
}
