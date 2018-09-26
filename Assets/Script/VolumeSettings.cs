﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour {

    public AudioMixer mixer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void ChangeMusicVolume(float vol)
    {
        mixer.SetFloat("MusicVolume", vol); 
        Debug.Log(vol);
    }

    public void ChangeSFXVolume(float vol)
    {
        mixer.SetFloat("SFXVolume", vol);
    }
}
