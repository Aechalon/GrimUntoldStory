using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrimDialogue : MonoBehaviour
{

    public GameObject Key;
    public int mobType;
    public int playerAct;
    public bool decision;
    public Camera camera;
    public Text victoryTxt;
    public Text msgTxt;
    public Text mobTxt;
    public Text txtHPPot;
    public Text txtMPPot;
    public Button Yes;
    public Button No;
    public Button btnAtk;
    public Button btnSkill;
    public Button btnInven;
    public Button btnRetreat;
    public Button btnDeathWish;
    public Button btnPsycheThirst;
    public Button btnForgottenGrave;
    public Button btnSkillBack;
    public Button btnInventoryBack;
    public Button mpPot;
    public Button hpPot;
    public GameObject MainUI;
    public GameObject inventoryTab;
    public GameObject btnYes;
    public GameObject btnNo;
    public GameObject btnAtkGO;
    public GameObject btnSkillGO;
    public GameObject btnInvenGO;
    public GameObject btnRetreatGO;
    public GameObject DialogueBox;
    public GameObject btnForgottenGraveGO;
    public GameObject btnPsycheThirstGO;
    public GameObject btnDeathWishGO;
    public GameObject btnSkillBackGO;
    public GrimStat grimStat;
    public BattleScript battleScript;
    public PlayerMovement playerMovement;
    public GameObject MainCamera;
    public GameObject subCamera;
    public GameManager gameManager;
    public WalkingAI ai;
    public NpcSoul npcSoul;
    bool i;

    public void StartGame()
    {
        ai = battleScript.ai;
        GameStart(1);

    }
    private void Update()
    {

        txtHPPot.text = "" + grimStat.hpPot + "x HP Pot";
        txtMPPot.text = "" + grimStat.mpPot + "x MP Pot";

        if (grimStat.mpPot < 1)
        {
            mpPot.interactable = false;
        }
        if (grimStat.hpPot < 1)
        {
            hpPot.interactable = false;
        }
        if (grimStat.tempHp < 1 || battleScript.Enemy.tempHp < 1)
        {

            
            BtnDisable();
            if (grimStat.tempHp < 1)
            {

                victoryTxt.text = "You were Defeated";

                battleScript.ai.isEnable = true;

            }
            if (battleScript.Enemy.tempHp < 1)
            {
                
                victoryTxt.text = "You caught a soul!";
               if(!i)
                {
                    SoulAdd();
                    i = true;
                    Invoke("GameEnd", 3f);
                }

                Invoke("LateAnimation", 3f);




            }
       
        }
    }
    public void SoulAdd()
    {
        grimStat.soulCount += 1;

    }
    private void LateDestroy()
    {
        battleScript.enemy.SetActive(false);
    }
    public void LateAnimation()
    {
        ai.animator.SetBool("isDead", true);
        ai.isEnable = false;
        Invoke("LateDestroy", 0.1f);
        i = false;
    }

    public void GameEnd ()
    {
       
        GameStart(0);
        if (gameManager.firstQuest)
        {
            if (battleScript.Enemy.enemyType == 2)
            {
                gameManager.firstQuest = false;
                gameManager.questCompleted = true;
                gameManager.SelfPopUp();

            }
        }
        if (gameManager.secondQuest)
        {
            if(grimStat.soulCount >= 5)
            { 
                gameManager.secondQuest = false;
                gameManager.questCompleted = true;
                gameManager.SelfPopUp();

            }
        }
        if (gameManager.finalQuest)
        {
            if (battleScript.Enemy.enemyType == 4)
            {
                gameManager.firstQuest = false;
                gameManager.questCompleted = true;
                gameManager.SelfPopUp();
                Key.SetActive(true);

            }
        }
    }
    private void MobTypeFunc(int mobType)
    {
        switch (mobType)
        {
            case 1:
                TextWriter.AddWriter_Static(mobTxt, "Lost Soul...", 0.05f, true);
                break;
            case 2:
                TextWriter.AddWriter_Static(mobTxt, "Sad Soul...", 0.05f, true);
                break;
            case 3:
                TextWriter.AddWriter_Static(mobTxt, "Mad Soul...", 0.05f, true);
                break;
            case 4:
                TextWriter.AddWriter_Static(mobTxt, "God...", 0.05f, true);
                break;

            default:
                TextWriter.AddWriter_Static(mobTxt, "Missing No.", 0.05f, true);
                break;
        }

    }
    
    public void PlayerAction(int playerAct)
    {

            switch (playerAct)
            {

                case 1:
                    battleScript.GrimAtk();
                    battleScript.AtkMsg(1);
                    BtnDisable();
                    TextWriter.AddWriter_Static(msgTxt, "Grim used Scythe", 0.05f, true);
                    EnemyTurn();

                    Invoke("BtnEnable", 1f);
                    break;
                case 2:
                    DisableSkillButtons();
                    ShowSkills();
                    Invoke("EnableSkillButtons", 1f);
                    ClearText();
                    TextWriter.AddWriter_Static(msgTxt, "Choose a Skill to use.", 0.05f, true);
                    break;
                case 3:
                    inventoryTab.SetActive(true);
                    InventoryDisable();
                      ClearText();
                    TextWriter.AddWriter_Static(msgTxt, "Choose an item.", 0.05f, true);
                    Invoke("InventoryEnable", 1f);
                    HideMain();
                    break;
                case 4:
                    TextWriter.AddWriter_Static(msgTxt, "Retreat Battle? ", 0.05f, true);
                    ConfirmShow();
                    ClearText();
                    break;
            }

     
    }
    public void BtnPsychThirst()
    {
     
        battleScript.GrimPS();
        EnemyTurn();
        ReturnMenu();

    }
    public void BtnForgottenGrave()
    {

        battleScript.GrimFG();
        EnemyTurn();
        ReturnMenu();
    }
    public void BtnDeathWish()
    {

        battleScript.GrimDW();
        EnemyTurn();
        ReturnMenu();
    }
    public void HpPot()
    {
        EnemyTurn();
        ReturnMenu();
        grimStat.hpPot -= 1;
        grimStat.tempHp += 50;
    }
    public void MpPot()
    {
        EnemyTurn();
        ReturnMenu();
        grimStat.mpPot -= 1;
        grimStat.tempMp += 100;

    }
    public void EnemyTurn()
    {
      
            int EnemyTurn = Random.Range(1, 100);
            if (EnemyTurn >= 50)
            {
                battleScript.EnemyAtk();

            }
            else
            {
            if (battleScript.Enemy.tempMp > 30)
            {
               
                battleScript.EnemySkill();
            }
            else
            {
                battleScript.EnemyAtk();
            }
            }
            battleScript.DmgReset();

    }
    public void decisionTest()
    {
        StartCoroutine(DecisionPhase());
    }
    public void GameStart(int i)
    {
      

        switch (i)
        {
            case 0:
                MainUI.SetActive(true);
               battleScript.battleBegin = false;
               playerMovement.isControlEnb = true;
                DialogueBox.SetActive(false);
                grimStat.StatusUpdate();
                battleScript.Enemy.StatusUpdate();
                gameManager.onBattle = false;   
                break;
            case 1:
                victoryTxt.text = "";
                battleScript.battleBegin = true;
                DialogueBox.SetActive(true);
                playerMovement.isControlEnb = false;
                MainUI.SetActive(false);
                StartCoroutine(GrimLines());
                ConfirmHide();
                gameManager.onBattle = true;
                break;
        }
       
    }
    public void ReturnMenu()
    {

              ClearText();
            StartCoroutine(GrimLines());
            ConfirmHide();
            HideSkills();
            BtnDisable();
            HideInventory();
        

    }
    IEnumerator GrimLines()
    {
        ClearText();
        BtnDisable();
        TextWriter.AddWriter_Static(msgTxt, "You have encountered a ", 0.05f, true);
        yield return new WaitForSeconds(1.5f);
        MobTypeFunc(battleScript.Enemy.enemyType);
        yield return new WaitForSeconds(0.8f);
        BtnEnable();

    }
    
    IEnumerator DecisionPhase()
    {
    
        PlayerAction(this.playerAct);           
        yield return new WaitForSeconds(0.01f);
    }
    public void InventoryDisable()
    {
        btnInventoryBack.interactable = false;
        mpPot.interactable = false;
        hpPot.interactable = false;
    }
    public void InventoryEnable()
    {
        btnInventoryBack.interactable = true;
        mpPot.interactable = true;
        hpPot.interactable = true;
    }
    public void ClearText()
    {
        msgTxt.text = "";
        mobTxt.text = "";
   
    }
    public void RetreatNo()
    {
        ReturnMenu();
        ConfirmHide();
    }
    public void RetreatYes()
    {
        battleScript.Retreat();
        if(battleScript.retreatChance > 50)
        {
            TextWriter.AddWriter_Static(msgTxt, "You have failed to Retreat. ", 0.05f, true);
            BtnDisable();
            EnemyTurn();
            Invoke("ReturnMenu", 2f);
        }
        else
        {
            GameStart(0);
        }
    }

    public void BtnDisable()
    {
        btnAtk.interactable = false;
        btnSkill.interactable = false;
        btnInven.interactable = false;
        btnRetreat.interactable = false;
        No.interactable = false;
        Yes.interactable = false;
    }
    public void BtnEnable()
    {
        btnAtk.interactable = true;
        btnSkill.interactable = true;
        btnInven.interactable = true;
        btnRetreat.interactable = true;
        No.interactable = true;
        Yes.interactable = true;
    }

    public void ShowSkills()
    {
        btnDeathWishGO.SetActive(true);
        btnForgottenGraveGO.SetActive(true);
        btnPsycheThirstGO.SetActive(true);
        btnSkillBackGO.SetActive(true);
        HideMain();
    }
    public void HideSkills()
    {
        btnDeathWishGO.SetActive(false);
        btnForgottenGraveGO.SetActive(false);
        btnPsycheThirstGO.SetActive(false);
        btnSkillBackGO.SetActive(false);
        ShowMain();
    }
   
    public void ConfirmShow()
    {
        btnYes.SetActive(true);
        btnNo.SetActive(true);
        btnInvenGO.SetActive(false);
        btnRetreatGO.SetActive(false);
        btnSkillGO.SetActive(false);
        btnAtkGO.SetActive(false);
    }
    public void ConfirmHide()
    {
        btnYes.SetActive(false);
        btnNo.SetActive(false);
        btnInvenGO.SetActive(true);
        btnRetreatGO.SetActive(true);
        btnSkillGO.SetActive(true);
        btnAtkGO.SetActive(true);
    }
    public void HideMain()
    {
        btnInvenGO.SetActive(false);
        btnRetreatGO.SetActive(false);
        btnSkillGO.SetActive(false);
        btnAtkGO.SetActive(false);
    }
    public void ShowMain()
    {
        btnInvenGO.SetActive(true);
        btnRetreatGO.SetActive(true);
        btnSkillGO.SetActive(true);
        btnAtkGO.SetActive(true);
    }
    public void DisableSkillButtons()
    {
        btnPsycheThirst.interactable = false;
        btnForgottenGrave.interactable = false;
        btnDeathWish.interactable = false;
        btnSkillBack.interactable = false;
    }
    public void EnableSkillButtons()
    {
        btnPsycheThirst.interactable = true;
        btnForgottenGrave.interactable = true;
        btnDeathWish.interactable = true;
        btnSkillBack.interactable = true;
    }
    public void HideInventory()
    {
        inventoryTab.SetActive(false);
    }
}
