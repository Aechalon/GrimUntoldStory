using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BtnSriptIntract : MonoBehaviour
{
    public int btnType;

    public Button btn;
    public NpcSoul npc;
    public Spawner spawner;
    public InteractionScript interaction;
    public GameObject StatsMenu;
    public void Start()
    {
        btn = GetComponent<Button>(); //Grabs the button component
    }
    public void StatMen()
    {
        StatsMenu.SetActive(true);
    }
    public void InteractButton()
    {
        switch (btnType)
        {
            case 1:
                btn.onClick.AddListener(interaction.spawner.SpawnSoul); //A
                break;
            case 2:
                btn.onClick.AddListener(npc.BtnInteract); //A
                 break;
           
        }
    }
}
