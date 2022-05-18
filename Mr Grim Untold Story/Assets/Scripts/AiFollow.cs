using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public GameManager gameManager;
    public float aiSpeed;
    public float lineofSight;
    public float shootingRange;
    public Transform player;
    public bool stopFollow;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
     
        if (!gameManager.onBattle)
        {
            if (!stopFollow)
            {
                if (distanceFromPlayer < lineofSight && distanceFromPlayer > shootingRange)
                {
              
                    transform.position = Vector2.MoveTowards(this.transform.position, player.position, aiSpeed * Time.deltaTime);

                }
                else if (distanceFromPlayer <= shootingRange)
                {
                    transform.position = Vector2.MoveTowards(this.transform.position, player.position, (aiSpeed * 2) * Time.deltaTime);
                }
            }
        }
        
    }
              
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineofSight );
        Gizmos.DrawWireSphere(transform.position,shootingRange);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            stopFollow = true;
        }
    }

}
 