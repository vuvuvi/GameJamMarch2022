using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] audioClips;
    public AudioSource audioSource;
    
    private float track;
   
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource.loop = true;
         
    }


    private AudioClip GetRandomClip()
    {
        return audioClips[Random.Range(0, audioClips.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = GetRandomClip();
            audioSource.Play();
        }
    }
}
