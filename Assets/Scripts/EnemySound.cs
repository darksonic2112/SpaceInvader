using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySound : MonoBehaviour
{
    public AudioClip deathSound;
    
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = deathSound;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Bullet"))
        {
            audioSource.Play();
        }
    }
}
