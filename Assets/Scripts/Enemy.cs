using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;
    public bool active = false;
    public bool canAct = true;
    public bool moving = false;
    
    public Vector3 target;
    public static float base_speed = 0.02f;
    
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        active = false;
        canAct = true;
        moving = false;
        
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
                    if (dist.sqrMagnitude > 0.5f)
                    {
                        dist.Normalize();

                        if (dist.x < 0)         this.GetComponent<SpriteRenderer>().flipX = true;
                        else if (dist.x > 0)    this.GetComponent<SpriteRenderer>().flipX = false;
                        
                        this.transform.position += dist * speed; 
                    
                    }
                    else{
                        moving = false;
                    }
                }
            }
        }

    }

    // called every 
    public IEnumerator Act()
    {
        float delay = Random.Range(0f, 1f);

        yield return new WaitForSeconds(delay);

        target = new Vector3(   player.transform.position.x + Random.Range(-1.5f, 1.5f),
                                player.transform.position.y + Random.Range(-1.5f, 1.5f),
                                player.transform.position.z 
                            );
        
        moving = true;

        yield return new WaitForSeconds(2-delay); // shorter delay when chasing player
        
        canAct = true;
    }

}
