using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackCol : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float knockbackStrength;
    public PlayerMovement playerMovement;

    public void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
       
       if (rb != null && playerMovement.isControlEnb )
        {

            Debug.Log("Did HIt?");
                Vector3 direction = collision.transform.position - transform.position;
                direction.z = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode2D.Impulse);

            
        }
    }
 
}