using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerRandom : MonoBehaviour
{
    public GameObject SadSoul;

    public GameObject LostSoul;
    public Transform location;
    public int spawnType;
    public float spawndur;
    int spawnAmount;
    bool spawn;
    public void Update()
    {

        SpawnRandom();
    }
    public void SpawnRandom()
    {
        spawnType = Random.Range(1, 3);
        if (spawn)
        {
            spawn = false;
            if (spawnAmount < 30)
            {
                switch (spawnType)
                {
                    case 1:
                        Instantiate(SadSoul, location.position, location.rotation);
                     
                        break;
                    case 2:
                        Instantiate(LostSoul, location.position, location.rotation);
                        
                        break;

                }
            }
        }
        if (spawndur < 10f)
        {
            spawndur += Time.deltaTime;
        }
        else
        {
            spawnAmount++;
            spawndur = 0;
            spawn = true;
            
        }
    }
}
