using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StatsMenu : MonoBehaviour
{
    public GameObject statMenu;
    public GrimStat grim;
    public double free = 100;

    public Text txtCons;
    public Text txtInt;
    public Text txtStr;
    public Text txtAgi;
    public Text txtLuk;
    public Text txtFree;


    public double cons = 1;
    public double intel = 1;
    public double str = 1;
    public double agi = 1;
    public double luk = 1;

    public void Update()
    {
        txtFree.text = "Free : " + free;
        txtStr.text = grim.str.ToString();
        txtCons.text = grim.cons.ToString();
        txtAgi.text = grim.agi.ToString();
        txtInt.text = grim.intel.ToString();
        txtLuk.text = grim.luk.ToString();
    }
    public void Done()
    {
        statMenu.SetActive(false);
    }
    public void Increment(int i)
    {
        if (free > 1)
        {
            switch (i)
            {
                case 1:
                    grim.cons += this.cons;
                    free -= 1;
                    break;
                case 2:
                    grim.intel += this.intel;
                    free -= 1;
                    break;
                case 3:
                    grim.str += this.str;
                    free -= 1;
                    break;
                case 4:
                    grim.agi += this.agi;
                    free -= 1;
                    break;
                case 5:
                    grim.luk += this.luk;
                    free -= 1;
                    break;

            }
        }


    }
    public void Decrement(int i)
    {
        if (free < 101 && free > -1)
        {
            switch (i)
            {
                case 1:
                    grim.cons -= this.cons;
                    free += 1;
                    break;
                case 2:
                    grim.intel -= this.intel;
                    free += 1;
                    break;
                case 3:
                    grim.str -= this.str;
                    free += 1;
                    break;
                case 4:
                    grim.agi -= this.agi;
                    free += 1;
                    break;
                case 5:
                    grim.luk -= this.luk;
                    free += 1;
                    break;

            }
        }


    }
}
