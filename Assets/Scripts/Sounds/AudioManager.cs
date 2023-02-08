using UnityEngine.Audio;
using System;
using UnityEngine;
//SOUND AND AUDIO MANAGER TAKEN FROM BRACKEYS VIDEO


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Awake() //this method is called just before Start method
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume; //referencing to sound 
            s.source.pitch = s.pitch;
        }

    }

    // Update is called once per frame
    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);//(arrow notation)
        s.source.Play();
    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
}   
