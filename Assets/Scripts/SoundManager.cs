using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip GlideSound,JumpSound,WalkSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        GlideSound = Resources.Load<AudioClip>("GlideAudio");
        JumpSound = Resources.Load<AudioClip>("JumpAudio");
        WalkSound = Resources.Load<AudioClip>("WalkAudio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string act)
    {


        switch (act)
        {
            case "Jump":
                audioSrc.PlayOneShot(JumpSound);
                break;
            case "Walk":
                audioSrc.PlayOneShot(WalkSound, 1.0f) ;
                break;


        }
    }
}
