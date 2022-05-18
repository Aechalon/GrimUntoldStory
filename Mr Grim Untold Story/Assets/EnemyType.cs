using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public GameObject sS;
    public GameObject lS;
    public GameObject aS;
    public GameObject Bb;
    public GameObject HC;
  
    public BattleScript mob;

    public void Update()
    {
        enemyType();
    }
    public void enemyType()
    {
        switch (mob.Enemy.enemyType)
        {
            case 1:
                sS.SetActive(false);
                lS.SetActive(true);
                Bb.SetActive(false);
                HC.SetActive(false);
                aS.SetActive(false);
                break;
            case 2:
                sS.SetActive(true);
                lS.SetActive(false) ;
                Bb.SetActive(false);
                HC.SetActive(false);
                aS.SetActive(false);
                break;
            case 3:
                sS.SetActive(false);
                lS.SetActive(false);
                Bb.SetActive(false);
                HC.SetActive(false);
                aS.SetActive(true);
                break;
            case 4:
                sS.SetActive(false);
                lS.SetActive(false);
                Bb.SetActive(true);
                aS.SetActive(false);
                HC.SetActive(false);
                break;
            case 5:
                sS.SetActive(false);
                lS.SetActive(false);
                Bb.SetActive(false);
                aS.SetActive(false);
                HC.SetActive(true);
                break;

        }
    }


}
