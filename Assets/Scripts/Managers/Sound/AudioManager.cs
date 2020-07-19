using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    //public GameObject lobby;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) // checks for audio manager in scene
            instance = this; // if there is none, then this object will be the audio manager
        else
        {
            Destroy(gameObject); // destroys this audio manager if scene already has one
            return; // makes sure no code is called before the object is destroyed
        }

        DontDestroyOnLoad(gameObject); // prevents this gameobject from getting destroyed should the scene change

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>(); // adds audio source 
            s.source.clip = s.clip; // clip of audio source

            s.source.volume = s.volume; // allows for control of volume
            s.source.pitch = s.pitch; // allows for control of pitch
            s.source.loop = s.loop; // allows for looping
        }
    }
    
    void Start()
    {
        Play("MainMenuTheme");
    }

    /* private void Update()
    {
        // checks whether GameObject lobby is active or not
        if (lobby.gameObject.activeSelf == true)
        {
            Play.("CharacterSelection");
        }
    } */

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // finds sound in sounds array and then find sound which sound.name = name (its stored in variable "s")
        if (s == null) // prevents the game from trying to play a sound that isnt there
            return;
        s.source.Play();
    }

}
