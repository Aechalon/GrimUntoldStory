using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class layerOrder : MonoBehaviour
{
    public Transform player;
    public SpriteRenderer sort;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sort = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(this.transform.position.y > player.transform.position.y)
        {
            sort.sortingOrder = 9;
        }
        else
        {

            sort.sortingOrder = 13;
        }
    }
}
