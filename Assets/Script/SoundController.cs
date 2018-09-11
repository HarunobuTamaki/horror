using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

    public AudioSource BGMChannel; //BGM再生用のAudioSource
    public AudioSource SEChannel;//SE再生用のAudioSource
    public AudioClip[] Musics;//BGMの格納用配列
    public AudioClip[] Sounds;//SEの格納用配列。Player、UI側で使用するSEは全てここに入れる

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
