using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingAI : MonoBehaviour
{
    
    public Animator animator;
    public bool isEnable;
    public Transform transform;
    public int direction;
    public float speed = 0.3f, x, y;
    public float distance;
    public float animatorSpeed;
    public void Start()
    {
        transform = GetComponent<Transform>();
        isEnable = true;
      
    }

    public void Update()
    {
        if (isEnable)
        {
            distance += Time.deltaTime;
            AIMovement();
        }
        animator.speed = animatorSpeed;
    }

    public void AIMovement()
    {

        if (distance > 5)
        {
             x = Random.Range(-0.01f, 0.01f);
             y = Random.Range(-0.01f, 0.01f);
            Animation();
            distance = 0;
        }
        else
        {
            transform.position += new Vector3(x, y) * speed;
              
            distance += Time.deltaTime;

           

        }
    }
    public void Animation()
    {
        if((x > 0.00) && (y>=-.1 && y<=.1 ))
        {
            animator.SetBool("isRight", true);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);

        }
        if ((x < 0.00) && (y >= -.1 && y <= .1))
        {

            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", true);
            animator.SetBool("isUp", false);

        }
        if ((x == 0.00) && (y>.1f))
        {

            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", true);

        }
        if ((x == 0.00) && (y > -.1f))
        {

            animator.SetBool("isRight", false);
            animator.SetBool("isLeft", false);
            animator.SetBool("isUp", false);

        }

    }



            /*
            if (distance > 3)
            {
                direction = Random.Range(1, 6);
                distance = 0;
            }
            else
            {
                switch (direction)
                {
                    case 1:
                        transform.position +=  Vector3.up  * speed * Time.deltaTime;

                        break;
                    case 2:
                        transform.position += Vector3.down * speed * Time.deltaTime;

                        break;
                    case 3:
                        transform.position += Vector3.left * speed * Time.deltaTime;

                        break;
                    case 4:
                        transform.position += Vector3.right * speed * Time.deltaTime;
                        break;
                    case 5:
                        transform.position += new Vector3(0.01f,.01f); 
                        break
                    case 6:
                        transform.position += new Vector3(-0.01f,-.01f);
                        break;

                }
            }*/

        
}
