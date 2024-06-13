using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScriptManager : MonoBehaviour
{
    
    public AudioClip[] clips = new AudioClip[2];
    private AudioSource audioSource;
    private int clipOrder = 0;
    public bool randomPlay = false; 
    public bool RightToPlay;
    
    void Start ()
     {
        audioSource = GetComponent<AudioSource> ();
        audioSource.loop = false;
        randomPlay = true;
    }

    void Update () {
        
        if(randomPlay)
        {
            if ( !audioSource.isPlaying) 
            {
            // if random play is selected
                if (randomPlay == true) 
                {
                    audioSource.clip = GetRandomClip ();
                    audioSource.Play ();
                // if random play is not selected
                } 
                else 
                {
                    audioSource.clip = GetNextClip ();
                    audioSource.Play ();
                }
            }
        }
             
            else
            {
                audioSource.Stop();
            }
            
        
       
    }

// function to get a random clip
private AudioClip GetRandomClip () {
    return clips[Random.Range (0, clips.Length)];
}

// function to get the next clip in order, then repeat from the beginning of the list.
private AudioClip GetNextClip () {
    if (clipOrder >= clips.Length - 1) {
        clipOrder = 0;
    } else {
        clipOrder += 1;
    }
    return clips[clipOrder];
}

}
