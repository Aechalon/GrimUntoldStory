using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public NpcSoul npc;
    public Text questUpdate;
    public Text currentQuest;
    public bool gameStart;
    public int questTracker;
    public bool onBattle;
    public bool questCompleted;
    public Camera MainCamera;
    public Camera SubCamera;

    public void Update()
    {
     
        switch (questTracker)
        {
            case 1:
                questUpdate.text = "Defeat a Sad Soul x" + 1;
                currentQuest.text = "Defeat a Sad Soul x" + 1;

                break;
            case 2:
                questUpdate.text = "Solve the Riddle";
                currentQuest.text = "Capture 5 Souls";
                break;
            case 3:
                questUpdate.text = "FEAR THE GOD";
                currentQuest.text = "Finish the Quest Somehow";
                break;


        }
     if(onBattle)
        {
            MainCamera.depth = 0;
            SubCamera.depth = 1;
        }
       else
        {
            MainCamera.depth = 1;
            SubCamera.depth = 0;
        }

     
    }
    public void SelfPopUp()
    {
        if (questCompleted)
        {
            questUpdate.text = "Quest Completed!";
            currentQuest.text = "";
            npc.QuestPopUp();
            questTracker = 0;
            Invoke("lateComplete", 3f);
        }
    }
    public void lateComplete()
    {
        questCompleted = false;
    }

    [Header("Tutorial Quest")]
    public bool firstQuest;
    public bool GodKey;


    [Header("Game Quest")]
    public bool secondQuest;


    [Header("Final Quest")]
    public bool finalQuest;
}
