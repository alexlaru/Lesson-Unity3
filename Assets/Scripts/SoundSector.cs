using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSector : MonoBehaviour
{
    private AudioSource _audio;
    public AudioClip AudioClip;
    [Min(0)]
    public float volume;
    [Min(0)]
    public float delay;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {

       _audio.PlayOneShot(AudioClip, volume);
        //    _audio.PlayDelayed(delay); //Задержка в проигрывании
    }
    private void OnDisable()
    {
        //   _audio.Stop();
    }
}
