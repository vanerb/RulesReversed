
using UnityEngine;
using UnityEngine.Audio;
using System;



public class AudioManager : MonoBehaviour
{
    public Sound[] sound;

    public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach ( Sound s in sound)
        {
           s.source = gameObject.AddComponent<AudioSource>();
           s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    public void Play (string name)
    {
       Sound s = Array.Find(sound, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();

    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sound, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Stop();
    }

    private void Start()
    {
       
    }


    private void Update()
    {
        
    }
}
