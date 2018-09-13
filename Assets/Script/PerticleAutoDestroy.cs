using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerticleAutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //パーティクル(子要素)終了時に自動的に消滅させる
        ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
        Destroy(gameObject,particleSystem.main.duration+1.5f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
