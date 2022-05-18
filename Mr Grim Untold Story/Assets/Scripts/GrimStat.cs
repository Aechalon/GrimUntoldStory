using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimStat : MonoBehaviour
{
    public int soulCount;
    public int mpPot;
    public int hpPot;
    //Base stats
    public double hp;
    public double mp;

    public double cons; 
    public double intel;
    public double str;
    public double agi;
    public double luk;

    //Final Stats
    public double lifesteal;
    public double atkDmg;
    public double def;
    public double tempHp;
    public double tempMp;
    public double dropRate;
    public double critDmg;
    public double deathWish;
    public double psycheThirst;
    public double forgottenGrave;


    public void Start()
    {
        ConvertionTable();
        StatusUpdate();
    }
    public void Update()
    {
        deathWish = (atkDmg * 3 * (soulCount));
        psycheThirst = atkDmg * .8; //w lifesteal
        forgottenGrave = atkDmg * 1.5 + (soulCount * .5);
        ConvertionTable();

    }

    public void ConvertionTable()
    {
        atkDmg = ((str * 2) + (intel * .5) + (soulCount *.5));
        critDmg = (atkDmg * 3) + (soulCount * 2);
        hp = ((cons * 5) + (str * .5) + soulCount);
        mp = ((intel * 5) +(cons *.5) + soulCount);
        def = ((cons * .8) + (str * .5) + soulCount);
        dropRate = ((luk * .8) +(soulCount * .1)) ;

    }
    public void StatusUpdate()
    {
        tempHp = hp;
        tempMp = mp;

    }
}