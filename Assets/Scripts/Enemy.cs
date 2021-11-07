using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;
    public bool stunned;
    public bool moving;

    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
        player = GameObject.FindObjectOfType<Player>();
        StartCoroutine("Act");

        // play some start animation? sfx?
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            
        }
    }

    // called every 
    IEnumerator Act()
    {
        if (!stunned)
        {
            moving = true;
            if (player.canPaint)
            {
                
            }
        }
        else 
        {
            moving = false;
        }

        yield return new WaitForSeconds(2.0f);
    }
}
