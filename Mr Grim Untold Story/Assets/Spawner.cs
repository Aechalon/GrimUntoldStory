using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float spawnTimer;
    [SerializeField] private int spawnSize;
    [SerializeField] private int spawnAmount;
    public bool random;
   
    public GameObject Torch;
    public GameObject SadSoul;
    public GameObject AngrySoul;
    public GameObject LostSoul;
    [SerializeField] private Transform location;
    [SerializeField] private int spawnType;
    bool spawned;
    public void Spawning()
    {
        spawned = true;
        switch (spawnType)
        {
            case 1:
                Instantiate(SadSoul, location.position, location.rotation);
                spawnAmount++;
                break;
            case 2:
                Instantiate(LostSoul, location.position, location.rotation);
                spawnAmount++;
                break;
            case 3:
                Instantiate(AngrySoul, location.position, location.rotation);
                spawnAmount++;
                break;
        }
    }
    public void SpawnSoul()
    {
      
        Torch.SetActive(false);
        if (!spawned)
        {
            if (!random)
            {
                Spawning();


            }
            else if (random)
            {

                spawnType = Random.Range(1, 4);
                spawnTimer = 0;
                Spawning();
            }
        }
        
    }


}
