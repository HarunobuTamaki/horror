using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllustZombieController : EnemyScript {

    float spanTimer = 0; //弾の生成間隔
    public float distanceAlpha=2.0f; //距離によって透明度を調節
    public GameObject enemyBullet; //enemyBulletオブジェクト
    public GameObject muzzle; //弾の発射位置

	// Use this for initialization
	public override void Start () {
        base.Start();
        enemyCode = "zombie_man";
	}

    // Update is called once per frame
    public override void Update () {
        base.Update();
        //画像を表示させているのでDistanceの値によって疑似的に見えにくくする(透明度1だと明るい)
        Color distanceColor = new Color(
            255, 255, 255, distanceAlpha / distance);
        Attack();
        gameObject.GetComponent<SpriteRenderer>().color = distanceColor;
    }

    //攻撃メソッド
    public override void Attack()
    {
        base.Attack();
        spanTimer += Time.deltaTime;
        //distanceが30以下5以上の場合
        if (distance <= 30 && distance >= 5)
        {
            //Playerの位置に向く
            transform.LookAt(target.transform);
            //向いた方向に進んでいく
            transform.position += transform.forward * Time.deltaTime * 2f;

        }
        //distanceが10以下5以上の場合
        if (distance <= 10 && distance >= 5)
        {
            //2秒間隔で弾を生成する
            if (spanTimer > 2.0f)
            {
                howl(enemyCode);//おたけび再生
                Instantiate(enemyBullet, muzzle.transform.position, transform.rotation);
                spanTimer = 0;
            }
        }
        
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
    }
}
