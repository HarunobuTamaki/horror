﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint :CheckPoint1 {

	// Use this for initialization
	protected override void Start () {
        gameObject.SetActive(false);
        base.Start();

	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
	}

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }
}
