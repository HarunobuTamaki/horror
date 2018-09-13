using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : CheckPointTrigger {

    bool isGoal; //ゴールフラグ

	// Use this for initialization
	protected override void Start () {

        base.Start();
        gameObject.SetActive(false);
        isGoal = false;
	}
	
	// Update is called once per frame
	protected override void Update () {
        base.Update();
        if (isGoal)
        {
            distanceText.SetActive(false);
            Destroy(gameObject);
        }
	}

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            isGoal = true;
            
        
    }
}
