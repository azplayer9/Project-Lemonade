using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    Player player;
    public bool stunned;

    // Start is called before the first frame update
    void Start()
    {
        stunned = false;
        player = GameObject.FindObjectOfType<Player>();
        InvokeRepeating("Act", 2.0f, 1.0f);

        // play some start animation? sfx?
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called every 
    void Act()
    {
        if (!stunned){
            if (player.canPaint){
                
            }
        }
    }
}
