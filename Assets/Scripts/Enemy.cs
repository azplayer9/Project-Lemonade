using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;
    public bool active;
    public bool stunned;
    public bool moving;
    public bool canAct;
    public bool hasBrush;
    public bool invincible;
    
    public Vector3 target;
    public static float base_speed = 0.02f;
    //public int hp = 2;
    public float speed;

    public static float minX = -3;
    public static float maxX = 3;
    public static float minY = -1;
    public static float maxY = 3;

    // Start is called before the first frame update
    void Start()
    {
        active = false;
        stunned = false;
        moving = false;
        canAct = true;
        hasBrush = false;
        invincible = false;

        player = GameObject.FindObjectOfType<Player>();
        //StartCoroutine("Act");
        speed = base_speed;

        // play some start animation? sfx?
    }

    // Update is called once per frame
    void Update()
    {
        if(active){
            if (canAct){
                canAct = false;
                StartCoroutine("Act");
            }
            else{
                
                if (moving)
                {
                    Vector3 dist = (Vector2)target - (Vector2)this.transform.position;
                    dist.Normalize();
                    this.transform.position += dist * speed; 
                    
                    Vector3 newD = this.transform.position - target;
                    if (newD.sqrMagnitude <= 0.1f)
                    {
                        moving = false;
                    }
                }
            }
        }

    }

    // called every 
    public IEnumerator Act()
    {
        float delay = 2.0f;
        if (!stunned)
        {
            moving = true;

            if (player.canPaint)
            {
                this.speed = base_speed * 2;
                target = new Vector3(player.transform.position.x + Random.Range(-1f, 1f),
                                     player.transform.position.y + Random.Range(-1f, 1f),
                                     player.transform.position.z 
                                     );
                delay = Random.Range(.5f, 1.5f); // shorter delay when chasing player
            }
            else
            {
                this.speed = base_speed;
                float dx = transform.position.x - player.transform.position.x;
                float dy = transform.position.y - player.transform.position.y;
                target = new Vector3(   Mathf.Min( Mathf.Max( Random.Range(-0.5f, 2.5f) * dx, minX), maxX ) , 
                                        Mathf.Min( Mathf.Max( Random.Range(-0.5f, 2.5f) * dy, minY), maxY ) ,
                                        -1);
            }
        }
        else 
        {
            moving = false;
        }

        yield return new WaitForSeconds(delay);

        stunned = false;
        canAct = true;
    }

    public IEnumerator SetInvincible()
    {
        if (invincible == false){
            invincible = true;

            yield return new WaitForSeconds(2.0f);

            invincible = false;
        }
    }

    void OnMouseDown()
    {
        // need brush to paint birds
        if (this.active && player.canPaint){
            // if you click on birb, birb stops moving
            StopCoroutine("Act");
            canAct = false;
            active = false;
            
            // disable birb collider so it cant steal your brush
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}
