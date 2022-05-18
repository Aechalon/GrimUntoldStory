using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayStatus : MonoBehaviour
{
    public Text txtHp;
    public Text txtMp;
    public Text txtSoul;
    public GrimStat grim;

    public void Update()
    {
        txtHp.text = " HP: " + grim.tempHp;
        txtSoul.text = "SOUL: " + grim.soulCount;
        txtMp.text = " MP: " + grim.tempMp;

    }
}
