using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public int enemyType;     
    //Base stats
    public double hp;
    public double mp;
    public double cons;
    public double intel;
    public double str;
    public double agi;
    public double luk;

    //Final Stats
    public double atkDmg;
    public double def;
    public double tempHp;
    public double tempMp;
    public double critDmg;

   

    public void Start()
    {
        ConvertionTable();
        StatusUpdate();
    }
    public void StatusUpdate()
    {
        tempHp = hp + 10;
        tempMp = mp + 10;
    }
  
    public void ConvertionTable()
    {
        atkDmg = str + 10;
        def = cons + 10;
        critDmg = agi + luk + 10;
           
    }

}
