using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{    

    //private float speed = .05f;
    //private float jump = 10f;
    //public bool canJump = true;
    public bool canPaint = false;
    public bool invincible = false;
    //public Animator animator;
    //public SpriteRenderer spriteRend;

    void Start()
    {
        //canJump = true;
        canPaint = false;
        invincible = false;
    }

    /*
    void FixedUpdate()
    {
        var axis = Input.GetAxisRaw("Horizontal");
        Vector3 pos = new Vector3(this.transform.position.x + speed * axis, 
                                    this.transform.position.y,
                                    this.transform.position.z);


        if( canJump && (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.Space)) )
        {
            this.GetComponent<Rigidbody2D>().AddForce( new Vector2(0, jump), ForceMode2D.Impulse );
            canJump = false;
        }

        animator.SetFloat("Speed", Mathf.Abs(speed * axis));

        if (axis < 0)
        {
            spriteRend.flipX = false;
        }
        else if (axis > 0)
        {
            spriteRend.flipX = true;
        }

        this.transform.position = pos;
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bucket")
        {
            this.canPaint = true;

            foreach (Enemy e in FindObjectsOfType<Enemy>())
            {
                e.active = true;
            }
            
            Object.Destroy(col.gameObject);
        }
        /*
        else if (col.gameObject.tag == "Enemy")
        {
            Enemy other = col.gameObject.GetComponent<Enemy>();

            
            // stun bird if invincible
            if(invincible)
            {            
                // stun + stop birb
                other.stunned = true;
                other.moving = false;
            }
            // take brush back if bird has brush and is not invincible 
            if (other.hasBrush && !other.invincible) 
            {
                // take brush back
                SetInvincible();

                other.hasBrush = false;
                other.stunned = true;
                other.moving = false;
                
                other.GetComponent<SpriteRenderer>().color = Color.white;

                canPaint = true;
            }
            // lose brush if bird is not stunned and you are not invincible
            else if (canPaint && !other.stunned && !invincible)
            {
                canPaint = false;

                other.SetInvincible();
                other.hasBrush = true;
                other.GetComponent<SpriteRenderer>().color = Color.red;
                
                other.Act();
            }

        }*/
    }

    /*
    public IEnumerator SetInvincible()
    {
        if (invincible == false){
            invincible = true;

            yield return new WaitForSeconds(3.0f);

            invincible = false;
        }
    }*/
}
