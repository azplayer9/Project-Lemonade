using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{    

    private float speed = .05f;
    private float jump = 10f;
    public bool canJump = true;
    public bool canPaint = false;

    void Start()
    {
        speed = .1f;
        canJump = true;
        canPaint = false;
    }

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
            speed /= 2;
        }

        this.transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (!canJump && col.gameObject.tag == "Ground")
        {
            canJump = true;
            speed *= 2;
        }
    }
}
