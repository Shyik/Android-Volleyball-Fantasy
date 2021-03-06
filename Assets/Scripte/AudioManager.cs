using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public SoundController[] sounds;
    void Awake()
    {
        foreach (SoundController s in sounds)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;

           s.source.volume = s.volume;
           s.source.pitch = s.pitch;
           s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("LevelMusic");
    }

    public void Play(string name)
    {
        SoundController s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " +name+ " not found!");
        }
        
        s.source.Play();
    }
}
