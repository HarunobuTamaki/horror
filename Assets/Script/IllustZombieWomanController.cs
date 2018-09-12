using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustZombieWomanController : EnemyScript {

    float spanTimer = 0; //鳴き声を上げる間隔

    // Use this for initialization
    public override void Start () {
        base.Start();
        enemyCode = "zombie_woman";
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
        spanTimer += Time.deltaTime;
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

        if (spanTimer > 0.5f)//0.5秒毎におたけびを上げ、間隔をリセット
        {
            howl(enemyCode);
            spanTimer = 0;
        }

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
