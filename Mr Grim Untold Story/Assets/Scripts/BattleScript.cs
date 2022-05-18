using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleScript : MonoBehaviour
{
    public GameObject enemy;
    public GrimDialogue grimDialogue;
    public WalkingAI ai;
    public GrimStat Grim;
    public EnemyStat Enemy;
    public Text txtGrim;
    public Text txtEnemy;
    public Animation txtGrimDmg;
    public Animation txtSoulDmg;
    public double dmg;
    public double enemydmg;
    public double retreatChance;
    public bool battleBegin;
    public Collider2D collision;
    
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        this.collision = collision;
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Enemy = collision.GetComponent<EnemyStat>();
            ai = collision.GetComponent<WalkingAI>();
            enemy = collision.gameObject;   
            
        }
        if (collision.gameObject.CompareTag("HpPot"))
        {
            Grim.hpPot += 5;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("MpPot"))
        {
            Grim.mpPot += 5;
            Destroy(collision.gameObject);

        }

    }
    
    public void EnemyAtk()
    {
        int critChance = Random.Range(1, 100);
       
        DmgDealth(Grim.def, Enemy.atkDmg);
        if (critChance > 90)
        {
            dmg += Enemy.critDmg;
        }
        Grim.tempHp = Grim.tempHp - dmg;
        EnemyAtkMsg(1);
     
    }
    public void EnemySkill()
    {
        Enemy.tempMp -= 30;
        DmgDealth(Grim.def, Enemy.atkDmg);
        dmg = dmg + Enemy.critDmg;
        Grim.tempHp = Grim.tempHp - dmg;
        EnemyAtkMsg(2);
    
    }
    public void GrimAtk()
    {
        DmgDealth(Enemy.def, Grim.atkDmg);
        Enemy.tempHp = Enemy.tempHp - dmg;
        AtkMsg(1);
        

    }

    public void GrimFG()
    {
        Grim.tempMp -= 50;
        DmgDealth(Enemy.def, Grim.forgottenGrave);
        dmg = dmg + Grim.critDmg;
        Enemy.tempHp = Enemy.tempHp - dmg;
        AtkMsg(3);
        DmgReset();
    }
    
    public void GrimPS()
    {
        Grim.tempMp -= 100;
        DmgDealth(Enemy.def, Grim.psycheThirst);
        Enemy.tempHp = Enemy.tempHp - dmg;
        GrimLifeSteal();
        AtkMsg(2);
        DmgReset();
    }
    public void GrimDW()
    {
        Grim.soulCount = 1;
        DmgDealth(Enemy.def, Grim.deathWish);
        dmg += (Grim.critDmg *5);
        Enemy.tempHp = Enemy.tempHp - dmg;
        AtkMsg(4);
        DmgReset();
    }
    public void Retreat()
    {
        int retreatChance = Random.Range(1, 100);
       
        this.retreatChance = retreatChance;
    }
    
    
    
    
    public void AtkMsg(int i)
    {

        switch (i)
        {
            case 1:
                txtGrim.text = "Grim went for Slash Attack \n" + dmg + " Damage" ;
            break;
            case 2:
                 txtGrim.text = "Grim casted a PsychThirst \n" + dmg + " Damage";    
            break;
            case 3:
                  txtGrim.text = "Grim casted ForgottenGrave \n" + dmg + " Damage"; 
            break;
            case 4:
                  txtGrim.text = "Grim casted DeathWish \n" + dmg + " Damage";
            break;

        }

        txtGrimDmg.Play();

    }
    public void EnemyAtkMsg(int i)
    {

        switch (i)
        {
            case 1:
                txtEnemy.text = "Enemy went for Normal Attack \n" + dmg + " Damage";
                break;
            case 2:
                txtEnemy.text = "Enemy casted a Skill \n" + dmg + " Damage";

                break;
         

        }
        Invoke("delayAnimation", 1f);

    

    }
    public void delayAnimation()
    {
       txtSoulDmg.Play();
    }
    public void DmgReset()
    {
        dmg = 0;
        this.enemydmg = 0;
    }
    public void DmgDealth(double def, double dmg)
    {
        dmg = def - dmg;
        if(dmg < 0)
        {
            dmg *= -1;
        }
        this.dmg = dmg;
        this.enemydmg = dmg;
    }
    public void GrimLifeSteal()
    {
        Grim.lifesteal = dmg * .9;
        Grim.tempHp += Grim.lifesteal;
        Grim.lifesteal = 0;
    }
}
  /* Reference Syntax
   *public Text txtBattleLog;
    public Button btnKnightAtk;
    public int movecounter;
    public KnightStats kS;
    public DragonStats dS;

    public bool knightWeaken;
    //knight stats


    //dragon stats


    public void BtnKnightAction()
    {

        btnKnightAtk.interactable = false;


        if (movecounter >= 1)
        {
            knightWeaken = false;
        }

        int KnightAction;
        if (knightWeaken == true)
        {
            KnightAction = Random.Range(1, 1);
            movecounter++;

        }
        else
        {
            movecounter = 0;
            KnightAction = Random.Range(1, 5);

        }




        if (KnightAction == 1)
        {
            int kCriticalChance = Random.Range(1, 100);
            if (kCriticalChance <= 33)
            {
                dS.dragonTempHealth = (dS.dragonTempHealth - (dS.dragonDefense - (kS.playerAtkDamage * 3)));
                txtBattleLog.text = "Knight dealt a critical damage" +
                    "\nDragon current hp is" + dS.dragonTempHealth + ".";
                if (knightWeaken)
                {
                    movecounter = +1;
                }
            }
            else
            {
                if (knightWeaken)
                {
                    movecounter = +1;
                }
                dS.dragonTempHealth = dS.dragonTempHealth - (dS.dragonDefense - kS.playerAtkDamage);
                txtBattleLog.text = "Knight dealt a normal damage" +
                    "\nDragon current hp is" + dS.dragonTempHealth + ".";
            }
        }
        if (KnightAction == 2)
        {
            int KnightHeal = Random.Range(1, 20);
            if (KnightHeal > 18)
            {
                kS.playerTempHp = kS.playerTempHp + 500;
                txtBattleLog.text = "Knight Healed for 500 HP " +
                       "\nKnight current hp is " + kS.playerTempHp + ".";
            }
            else
            {
                kS.playerTempHp = kS.playerTempHp + 40;
                txtBattleLog.text = "Knight Healed for 40 HP " +
                       "\nKnight current hp is " + kS.playerTempHp + ".";
            }
        }
        if (KnightAction == 4)
        {
            int KnightBlackHole = Random.Range(1, 100);
            if (KnightBlackHole > 96) //install
            {
                dS.dragonTempHealth = 0;
                txtBattleLog.text = "Knight succesfully casted a blackhole " +
                      "\nDragon Defeated";
                btnKnightAtk.interactable = false;
            }
            else
            {
                kS.playerTempHp = kS.playerTempHp - 5;
                txtBattleLog.text = "Knight Failed to Cast Blackhole " +
                     "\nKnight hurt himself, current hp is " + kS.playerTempHp + ".";
            }
        }
        if (KnightAction == 3)
        {
            int FlamingArrow = Random.Range(1, 30);
            if (FlamingArrow > 25)
            {
                dS.dragonTempHealth = dS.dragonTempHealth - 450;
                txtBattleLog.text = "Knight's Flaming Arrow penetrated!" +
                    "\n -450 HP Dragon current hp is" + dS.dragonTempHealth + ".";
            }
            else
            {
                dS.dragonTempHealth = dS.dragonTempHealth - 450;
                txtBattleLog.text = "Knight's used Flaming arrow" +
                    "\n-100HP Dragon current hp is" + dS.dragonTempHealth + ".";
                dS.dragonTempHealth = dS.dragonTempHealth - 100;
            }
        }


        if (dS.dragonTempHealth <= 0)
        {
            Invoke("Defeat", 1f);
        }
        else
        {
            Invoke("DragonAction", 1.5f);
        }
    }

    public void DragonAction()
    {
        int DragonAction = Random.Range(1, 5);
        if (DragonAction == 1)
        {
            int kDodge = Random.Range(1, 100);
            if (kDodge < kS.playerDodgeRate)
            {
                txtBattleLog.text = "Knight dodges the dragon's attack";
            }
            else
            {
                int dInstaKill = Random.Range(1, 100);
                if (dInstaKill < 75) //normal
                {
                    kS.playerTempHp = (kS.playerTempHp - (kS.playerDefense - dS.dragonAtkDamage));
                    txtBattleLog.text = "Dragon hit the knight" +
                    "\nKnight current hp is" + kS.playerTempHp + ".";
                }
                else //instakill
                {
                    kS.playerTempHp = 0;
                    txtBattleLog.text = "Dragon instantly killed the knight";
                }
            }
        }
        if (DragonAction == 2) //claw attack
        {
            int ClawHit = Random.Range(1, 50);
            if (ClawHit > 40)
            {
                kS.playerTempHp = kS.playerTempHp - dS.dragonAtkDamage;
                txtBattleLog.text = "Dragon Claw Attack penetrates armor" +
              "\n Knight current HP is " + kS.playerTempHp;
            }
            else
            {
                txtBattleLog.text = "Dragon missed claw attack!" +
                    "\n Knight current HP is " + kS.playerTempHp;
            }
        }
        if (DragonAction == 3) //regain hp
        {
            int Revita = Random.Range(1, 100);
            if (Revita > 90)
            {
                dS.dragonTempHealth = dS.dragonHealth;
                txtBattleLog.text = "Dragon Revitalized!" +
                "\nDragon current HP is " + dS.dragonTempHealth;
            }
            else
            {
                txtBattleLog.text = "Dragon Failed to Revitalize" +
              "\n Dragon current HP is " + dS.dragonTempHealth;
            }
        }
        if (DragonAction == 4) //weaken
        {
            knightWeaken = true;

            txtBattleLog.text = "Dragon weaken Knight" +
          "\n Knight cannot use skills for 1 turn";
        }

        if (kS.playerTempHp <= 0)
        {
            Invoke("Defeat", 1f);
        }
        else
        {
            btnKnightAtk.interactable = true;
        }


    }

    void Defeat()
    {
        btnKnightAtk.interactable = false;
        if (kS.playerTempHp <= 0)
        {
            txtBattleLog.text = "Knight is defeated";
        }

        if (dS.dragonTempHealth <= 0)
        {
            txtBattleLog.text = "Dragon is defeated";
        }
    }
    */

