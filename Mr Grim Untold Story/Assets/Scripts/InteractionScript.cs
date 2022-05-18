using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InteractionScript : MonoBehaviour
{
    public NpcSoul npcSoul;
    public Spawner spawner;
    public Button btnInteract;
    public BtnSriptIntract btn;
    public battleStart battleSoul;
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            battleSoul = collision.GetComponent<battleStart>();
          
            btnInteract.interactable = true;
            npcSoul.npcType = 1;
            btn.btnType = 2;
        }
        if (collision.gameObject.CompareTag("Torch"))
        {
            spawner = collision.GetComponent<Spawner>();
            btnInteract.interactable = true;
            btn.btnType = 1;
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            
            btnInteract.interactable = true;
            btn.btnType = 2;
            npcSoul.npcType = 2;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Soul"))
        {
            btnInteract.interactable = false;
            npcSoul.npcType = 0;
            btn.btnType = 0;
        }
        if (collision.gameObject.CompareTag("Torch"))
        {
        
            btnInteract.interactable = false;
            btn.btnType = 0;
        }
    }
}
