using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaMan : MonoBehaviour
{
    public float velocityx = 4;
    public float Salto = 15; 
    
    private float mytime = 0f;

    public GameObject rightBullet;
    public GameObject leftBullet;

    public GameObject rightmedio;
    public GameObject leftmedio;

    public GameObject rightgrande;
    public GameObject leftgrande;

    private SpriteRenderer sr;    
    private Animator animator;
    private Rigidbody2D rb;

    private const int IDLE= 0;
    private const int JUMP= 2;    
    private const int RUN= 1;
    private const int CORRE_DISPARA= 3;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator =GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        

        rb.velocity = new Vector2(0, rb.velocity.y);
        
        changeAnimation(IDLE);  
        
        if(Input.GetKeyUp(KeyCode.W))
        {              
            if(sr.enabled ==false){sr.enabled=true;}
            rb.AddForce(Vector2.up * Salto, ForceMode2D.Impulse); //Salto  
            changeAnimation(JUMP);
        }

         if(Input.GetKey(KeyCode.A))
        { 
            if(sr.enabled ==false){sr.enabled=true;}
              //Correr en Reversa
              rb.velocity = new Vector2(-velocityx, rb.velocity.y); 
              sr.flipX = true;
              changeAnimation(RUN);
        }

        if(Input.GetKey(KeyCode.D))
        { 
            if(sr.enabled ==false){sr.enabled=true;}
              //Correr 
              rb.velocity = new Vector2(velocityx, rb.velocity.y); 
              sr.flipX = false;
              changeAnimation(RUN);
        }


        if (Input.GetKey(KeyCode.X)){
            mytime += Time.deltaTime;
            
            if (sr.color == Color.red)
            {
                sr.color= Color.white;
            }
            sr.color= Color.red;
        }
        if (Input.GetKeyUp(KeyCode.X))
        {   
            //sr.enabled = !sr.enabled;
            changeAnimation(CORRE_DISPARA);
            if (sr.color == Color.red)
            {
                sr.color= Color.white;
            }
            if (mytime >= 5)
            {   
                changeAnimation(CORRE_DISPARA);
                var bullet = sr.flipX ? leftgrande : rightgrande;
                var position2 = new Vector2(transform.position.x,transform.position.y);
                var rotation2 = rightBullet.transform.rotation;
                Instantiate(leftgrande,position2,rotation2);
            }
            else
            {
                if (mytime >= 3)
                {
                    changeAnimation(CORRE_DISPARA);
                var bullet = sr.flipX ? leftmedio : rightmedio;
                var position1 = new Vector2(transform.position.x,transform.position.y);
                var rotation1 = rightmedio.transform.rotation;
                Instantiate(rightmedio,position1,rotation1);
                }
                else
                {
                changeAnimation(CORRE_DISPARA);
                var bullet = sr.flipX ? leftBullet : rightBullet;
                var position = new Vector2(transform.position.x,transform.position.y);
                var rotation = rightBullet.transform.rotation;
                Instantiate(rightBullet,position,rotation);
                }
            }
                                    
        }  mytime = 0;
    }


    private void changeAnimation(int animation)
    {
        animator.SetInteger("Estado", animation);
    }
    
}
