using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnReward : MonoBehaviour
{
    public GameObject Reward;
    public GrimStat grimStat;
    public Animator Anim;
    public GameObject RewardSoul;
    public Transform transformex;

    int spawn;
    public bool spawnnow;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
          {
            Anim.SetBool("isOpen", true);
            Reward.SetActive(true);
            grimStat.soulCount = 5000;
            spawnnow = true;
          }
    }
    public void Update()
    {
        if (spawnnow)
        {
            if (spawn < 300)
            {
                Instantiate(RewardSoul, transformex.position, transformex.rotation);
                spawn++;
            }
            else
            { spawnnow = false; }
        }
       
      
    }
}
