using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sfxSetups;

    public AudioSource musicSource;

    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetMusicByType(musicType);
       musicSource.clip = music.musicAudioClip;
       musicSource.Play();
    }    
    

    public MusicSetup GetMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    public SFXSetup GetSFXByType(SFXType sfxType)
    {
        return sfxSetups.Find(i => i.sfxType == sfxType);
    }

}

public enum MusicType
{
    TYPE01,
    TYPE02,
    TYPE03
}

public enum SFXType
{
    NONE,
    SFX01,
    SFE02,
    SFX03
}

[System.Serializable]
public class MusicSetup
{
    public MusicType musicType;
    public AudioClip musicAudioClip;
}

[System.Serializable]
public class SFXSetup
{
    public SFXType sfxType;
    public AudioClip sfxAudioClip;
}
