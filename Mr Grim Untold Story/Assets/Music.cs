using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource audio1;
    public AudioSource audio2;
    // Update is called once per frame
    void Update()
    {
        if (gameManager.onBattle)
        {
            audio1.Play();
          
        }
        else
        {
            
            audio2.Play();
        }


    }
}
