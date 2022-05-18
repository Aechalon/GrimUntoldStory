using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActive : MonoBehaviour
{
    public GameObject BattleScene;
    public GameObject Main;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
         {
             BattleScene.SetActive(true);
             Main.SetActive(true);
        }
    }
}
