using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public MusicType musicType;
    public AudioSource audioSource;

    private MusicSetup _currMusicSetup;

    private void Start()
    {
        Play();
    }

    private void Play()
    {
        _currMusicSetup = SoundManager.Instance.GetMusicByType(musicType);

        audioSource.clip = _currMusicSetup.musicAudioClip;
        audioSource.Play();
    }




}
