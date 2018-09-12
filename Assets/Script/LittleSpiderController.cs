using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleSpiderController : EnemyScript {

    public GameObject spiderBullet;
    float spanTimer = 0;

	     // Use this for initialization
	public override void  Start () {
        base.Start();
        typeCode = 2;
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        spanTimer += Time.deltaTime;
        //distanceが30以下の場合Playerの方向に向き射撃する
        if (distance<=30)
        {
            transform.LookAt(target.transform);
            //2.5秒間隔で射撃
            if (spanTimer > 2.5f)
            {
                Instantiate(spiderBullet, transform.position, transform.rotation);
                spanTimer = 0;
            }

        }
	}

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
