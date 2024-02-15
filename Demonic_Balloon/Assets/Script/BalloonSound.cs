using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSound : MonoBehaviour
{
    
        public AudioClip soundClip;
        public float volume = 1.0f; 
    
        private AudioSource audioSource;
    
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = soundClip;
            audioSource.volume = volume;
        }
    
        void OnCollisionEnter(Collision collision)
        {
            audioSource.Play();
        }
    
}
