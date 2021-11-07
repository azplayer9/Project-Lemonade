using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class splatAnimation : MonoBehaviour
{
    //array, bool, and int to keep track of curr image
    // Start is called before the first frame update
    [SerializeField] Sprite[] splatImages;
    [SerializeField] float secondsPerFrame;
    [SerializeField] SpriteRenderer currMask;
    bool done = false;
    int currImageIndex = 0;
    float timer = 0;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!done) {
            timer += Time.deltaTime;
            if (timer>secondsPerFrame) {
                currMask.sprite = splatImages[currImageIndex];
                currImageIndex++;
                timer = 0;
                if (currImageIndex >= splatImages.Length) {
                    done = true;
                }
            } 
        }
    }
}
