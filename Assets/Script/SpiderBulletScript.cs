﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBulletScript : EnemyBulletScript {

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
	}

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}