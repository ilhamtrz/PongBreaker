using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 

    public static AudioManager Instance;
    
    void Awake()
    {
        CreateInstance();
    }

    void Start ()
    {
        InitSounds();
        Play("bgm");
    }

    public void Play (string soundName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);
        if (sound == null)
        {
            Debug.LogWarning("Sound: " + " not found!");
            return;
        }
            
        sound.source.Play();
    }

    private void InitSounds()
    {
        foreach (Sound sound in sounds)
        {
            sound.source        = gameObject.AddComponent<AudioSource>();
            sound.source.clip   = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch  = sound.pitch;
            sound.source.loop   = sound.loop;
        }
    }

    private void CreateInstance()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
    }
}
