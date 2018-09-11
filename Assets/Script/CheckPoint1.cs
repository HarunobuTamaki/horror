using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : CheckPointTrigger {

    // Use this for initialization
     protected override void Start () {
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
