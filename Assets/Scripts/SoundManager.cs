using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip VictorySound, JumpSound,WalkSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
        VictorySound = Resources.Load<AudioClip>("VictoryAudio");
        JumpSound = Resources.Load<AudioClip>("JumpAudio");
        WalkSound = Resources.Load<AudioClip>("WalkAudio");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string act)
    {
        if (!audioSrc.isPlaying)
        {

            switch (act)
            {
                case "Jump":
                    audioSrc.PlayOneShot(JumpSound);
                    break;
                case "Victory":
                    audioSrc.PlayOneShot(VictorySound);
                    break;


            }
        }
    }
}
