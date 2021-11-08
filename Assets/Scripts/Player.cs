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
        
        else if (col.gameObject.tag == "Enemy")
        {
            Enemy other = col.gameObject.GetComponent<Enemy>();
            
            other.active = true; // set bird to active if in the zone
            other.GetComponent<Animator>().Play("flap");
        }
    }
}
