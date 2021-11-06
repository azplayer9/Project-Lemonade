using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{    

    private float speed = .05f;
    private float jump = 10f;
    public bool canJump = true;

    void Start()
    {
        canJump = true;
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
        }

        this.transform.position = pos;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
}
