using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepPlayer : MonoBehaviour {

    public AudioClip[] footStepSounds;

    [Range(0,1)]
    public float volumeScale;

    [Range(0, 0.1f)]
    public float minVelocityToPlaySound = 0.05f;

    private int lenght;
    private bool isPlayingSound;
    private Vector3 previousPosition;
    private AudioSource audioSource;

    void Awake () {
        lenght = footStepSounds.Length;
        isPlayingSound = false;
	}

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        previousPosition = gameObject.transform.position;
    }

    void FixedUpdate()
    {
        Vector2 velocity = previousPosition - gameObject.transform.position;
        previousPosition = gameObject.transform.position;

        if (!audioSource.isPlaying && velocity.magnitude > minVelocityToPlaySound)
        {
            PlayRandomFootStepSound();
        }
    }
	
	public void PlayRandomFootStepSound()
    {
        int nextInt = Random.Range(0, lenght);
        audioSource.clip = footStepSounds[nextInt];
        audioSource.Play();
    }

    public void StopPlayingSound()
    {
        audioSource.Stop();
    }
}
