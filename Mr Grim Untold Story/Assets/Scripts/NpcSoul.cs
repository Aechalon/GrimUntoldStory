using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NpcSoul : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement playerMovement;
    public Animation questPopUp;
    public GameObject questPopUpGO;
    public Spawner spawn;
    public Text txtSoul;
    public Text txtGrim;
  
    public GameObject soulPanel;
    public GameObject grimPanel;
    private bool firstEncounter;
    public bool isInteract;
    public bool isAllowed;
    public int npcType;


    // Start is called before the first frame update
    //  private void OnTriggerEnter2D(Collider2D collision)

    public void BtnInteract()
    {
       switch(npcType)
        {
            case 1:
                if (!firstEncounter)
                {
                    playerMovement.isControlEnb = false;
                    StartCoroutine(NpcLines());
                    npcType = 0;
                }
                if (firstEncounter)
                {
                    StartCoroutine(Interacted());
                    npcType = 0;
                }
                break;

            case 2:
                if (!firstEncounter)
                {
                    playerMovement.isControlEnb = false;
                    StartCoroutine(StoneNpc());
                    npcType = 0;
                }
              
                break;
        }
      
    }
   
    public void TextClear()
    {
        TextWriter.AddWriter_Static(txtSoul, "", 0.05f, true);
    }

    public void QuestPopUp()
    {
        questPopUpGO.SetActive(true);
        questPopUp.Play();
        playerMovement.isControlEnb = true;
    }
    public void SoulLinePanel()
    {
        grimPanel.SetActive(false);
        soulPanel.SetActive(true);
    }
    public void GrimLinePanel()
    {
        grimPanel.SetActive(true);
        soulPanel.SetActive(false);
    }
    public void NoPanel()
    {
        grimPanel.SetActive(false);
        soulPanel.SetActive(false);
    }
    IEnumerator Interacted()
    {
        NoPanel();
        yield return new WaitForSeconds(0.1f);
        SoulLinePanel();
        TextWriter.AddWriter_Static(txtSoul, "þã ðωφúìσ ðšçü äωðωƶæ ðïþðäð ωð.", 0.05f, true);
        yield return new WaitForSeconds(3f);
        NoPanel();
        playerMovement.isControlEnb = true;
 

    }
    IEnumerator NpcLines()
    {
       
        NoPanel();
        yield return new WaitForSeconds(0.1f);
        SoulLinePanel();
        TextWriter.AddWriter_Static(txtSoul, "þγãèḍê þωðωßωωþð ððüèγþ.", 0.05f, true);
        yield return new WaitForSeconds(3f);
        TextWriter.AddWriter_Static(txtSoul, "ôωḥωð, ẓγω ωωþœ ωöþþóσðòð βìþσòë îþ.", 0.05f, true);
        yield return new WaitForSeconds(5f);
        GrimLinePanel();
        TextWriter.AddWriter_Static(txtGrim, "Yeah okay I'll find one.", 0.05f, true);
        yield return new WaitForSeconds(4f);
        NoPanel();
        gameManager.questTracker = 1;
        gameManager.firstQuest = true;
        QuestPopUp();
        yield return new WaitForSeconds(6f);
        questPopUpGO.SetActive(false);
        firstEncounter = true;
    
     
    



    }
    IEnumerator StoneNpc()
    {
        GrimLinePanel();
        yield return new WaitForSeconds(0.1f);

        TextWriter.AddWriter_Static(txtGrim, "Ah.. Agate Obelisk. Let's see here..", 0.05f, true);
    
        yield return new WaitForSeconds(3f);
        TextWriter.AddWriter_Static(txtGrim, "Dancing upon a greater day,", 0.05f, true);
        yield return new WaitForSeconds(3f);
        TextWriter.AddWriter_Static(txtGrim, "The Weeping once had come to play.", 0.05f, true);
        yield return new WaitForSeconds(3f);
        TextWriter.AddWriter_Static(txtGrim, "Yel throughout the quantraint seasons,", 0.05f, true);
        yield return new WaitForSeconds(3f);
        TextWriter.AddWriter_Static(txtGrim, "It never knew the reasons. ", 0.05f, true);
        yield return new WaitForSeconds(2f);
        TextWriter.AddWriter_Static(txtGrim, "What a mouthful.. ", 0.05f, true);
        yield return new WaitForSeconds(3f);
        NoPanel();
        gameManager.questTracker = 2;
        gameManager.firstQuest = true;
        playerMovement.isControlEnb = true;
        QuestPopUp();
     
        

    }
}

