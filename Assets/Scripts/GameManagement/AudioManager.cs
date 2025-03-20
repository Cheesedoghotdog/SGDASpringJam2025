using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, SFXSource;

    public void PlayMusic(string name) {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s == null) {
            Debug.Log("No Sounds");
        } else {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name) {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if(s == null) {
            Debug.Log("No Sounds");
        } else {
            SFXSource.clip = s.clip;
            SFXSource.Play();
        }
    }

    private void Start() {
        PlayMusic("Menu");
    }

}