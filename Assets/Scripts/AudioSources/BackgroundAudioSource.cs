using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioSource : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Start()
    {
        _audioSource.Play();
    }
}
