using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerMovement: MonoBehaviour
{

    public Joystick joystick;
    public Animator animController;
    public float speed = 1.2f;
    public float idleTime = .2f;
    public bool isMove;
    public bool isRun;
    public bool isControlEnb;
    public Rigidbody2D myRigidBody;
    public Collider2D myCollider;
    public Transform myTransform;
    public Transform grimFront;



    //Mask variables
    public LayerMask whatIsGround;
    public bool isGrounded;

    private void Start()
    {

        isControlEnb = true;
  
        myRigidBody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        myCollider = GetComponent<Collider2D>();
       
    }
    void Update()
    {
      
        PlayerControl();
        speedControl();

    }

    public void onPress()
    {
        
            isRun = true;
        
    }
    public void onRelease()
    {

            isRun = false;

    }
    public void speedControl()
    {
        if(isRun)
        {
            speed = 2.3f;
            animController.speed = 2.1f;
        }
        else
        {
            speed = 1.2f;
            animController.speed = 1.0f;
        }
    }
    void PlayerControl()
    {
        if (isControlEnb)
        {
     

                if (Input.GetKey(KeyCode.W)|| joystick.Vertical >= .3f)
                {
                    transform.position += Vector3.up * speed * Time.deltaTime;
                    animController.SetBool("isUp", false);
                    animController.SetBool("isDown", true);
                    animController.SetBool("isLeft", false);
                    animController.SetBool("isRight", false);
                    isMove = true;

                }


                else if (Input.GetKey(KeyCode.S)|| joystick.Vertical <= -.3f)
                {
                    transform.position += Vector3.down * speed * Time.deltaTime;
                    animController.SetBool("isUp", true);
                    animController.SetBool("isDown", false);
                    animController.SetBool("isLeft", false);
                    animController.SetBool("isRight", false);
                    isMove = true;
                }


                else if (Input.GetKey(KeyCode.D) || joystick.Horizontal >= .3f)
                {
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    animController.SetBool("isUp", false);
                    animController.SetBool("isDown", false);
                    animController.SetBool("isLeft", false);
                    animController.SetBool("isRight", true);
                    isMove = true;
                }

                else if (Input.GetKey(KeyCode.A) || joystick.Horizontal <= -.3f)
                {
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    animController.SetBool("isUp", false);
                    animController.SetBool("isDown", false);
                    animController.SetBool("isLeft", true);
                    animController.SetBool("isRight", false);
                    isMove = true;
                }


                else if (Input.GetKeyDown(KeyCode.E))
                {

                }
                else
                {
                    isMove = false;
                }



                if (!isMove)
                {
                    idleTime -= Time.deltaTime;
                }
                else
                {
                    idleTime = .2f;
                }
                if (idleTime <= 0)
                {
                    animController.SetBool("isUp", false);
                    animController.SetBool("isDown", false);
                    animController.SetBool("isLeft", false);
                    animController.SetBool("isRight", false);
                    idleTime = 0;
                }


            }
           
            
            
   
      
    }

}
