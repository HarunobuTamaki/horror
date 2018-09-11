using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustZombieWomanController : EnemyScript {

	// Use this for initialization
	public override void Start () {
        base.Start();
        typeCode = 1;
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        //距離によって透明度を変更する
        Color distanceColor = new Color
            (1, 1, 1, 4.0f / distance);
        Attack();
        gameObject.GetComponent<SpriteRenderer>().color = distanceColor;
    }

    //攻撃メソッド
    public override void Attack()
    {
        base.Attack();
        //distanceが30以下10以上の場合Playerの方向に向く
        if (distance <= 30 && distance > 10)
        {
            transform.LookAt(target.transform);
        }
        //distanceが20以下1以上の場合向いている方向に進む
        if (distance <= 20 && distance >= 1)
        {
            transform.position += transform.forward * Time.deltaTime * 10;
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }

}
