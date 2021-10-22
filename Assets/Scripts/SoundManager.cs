using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundManager : MonoBehaviour
{
    //SOUNDS
    public Sound[] sounds;

    //AUDIO SOURCES
    private List<AudioSource> audioSources = new List<AudioSource>();
    private AudioSource gameMusicSource;

    //INSTANCE
    public static SoundManager Instance;

    //SOUND TYPES
    public enum SoundType
    {
        GameMusic,
        CoinSound,
        LevelFinishSound
    }

    //SOUND TYPES to SOUND NAMES as STRING
    public Dictionary<SoundType, string> SoundName = new Dictionary<SoundType, string>()
    {
        [SoundType.GameMusic] = "GameMusic",
        [SoundType.CoinSound] = "CoinSound",
        [SoundType.LevelFinishSound] = "LevelFinishSound"
    };




    void Awake()
    {

        //SET SOUND MANAGER INSTANCE
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            Instance = this;
        }

        //DONT DESTROY ON LOAD
        DontDestroyOnLoad(this.gameObject);

        //SET AUDIO CLIP ATTRIBUTES
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            audioSources.Add(s.source);

            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.spatialBlend = s.spatialBlend;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;

            if (s.name == SoundName[SoundType.GameMusic])
            {
                gameMusicSource = s.source;
            }
        }

        PlaySound(SoundName[SoundType.GameMusic]);

    }

    
    //PLAYS THE GIVEN SOUND CLIP
    public void PlaySound(string name)
    {

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if(s == null)
        {
            Debug.LogWarning("Sound Clip: "+ s + "not found!");
            return;
        }

        s.source.Play();

    }

    //PLAYS THE GIVEN SOUND EFFECT
    public void PlaySoundEffect(SoundType s)
    {
        switch (s)
        {
            case SoundType.CoinSound:
                PlaySound(SoundName[SoundType.CoinSound]);
                break;

            case SoundType.LevelFinishSound:
                PlaySound(SoundName[SoundType.LevelFinishSound]);
                break;
        }
    }

    
    //STOPS or PLAYS THE GAME MUSIC
    public void SetGameMusic(bool value)
    {
        switch (value)
        {
            case false:
                gameMusicSource.Stop();
                break;

            case true:
                gameMusicSource.Play();
                break;
        }
    }
    
    //MUTES ALL THE SOUND EFEFCTS and MUSIC
    public void MuteGame()
    {
        foreach(AudioSource a in audioSources)
        {
            a.mute = true;
        }
    }

    //UNMUTES ALL THE SOUND EFFECTS and MUSIC
    public void UnmuteGame()
    {
        foreach (AudioSource a in audioSources)
        {
            a.mute = false;
        }
    }


    

}
