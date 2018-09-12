using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleSpiderController : EnemyScript
{

    public GameObject spiderBullet;
    float spanTimer = 0;

    Animator anim;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        //死亡時ディレイを定義
        deathDelay = 1.3f;        //enemyCode設定
        enemyCode = "littleSpider";
        //自身のanimatorを取得
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //死んでない時のみ攻撃処理
        if (!isDead)
        {
            spanTimer += Time.deltaTime;
            //distanceが30以下の場合Playerの方向に向き射撃する
            if (distance <= 30)
            {
                transform.LookAt(target.transform);
                //2.5秒間隔で射撃
                if (spanTimer > 2.5f)
                {
                    //攻撃モーション再生
                    anim.SetTrigger("Attack");
                    //おたけび再生
                    howl(enemyCode);
                    Instantiate(spiderBullet, transform.position, transform.rotation);
                    spanTimer = 0;
                }

            }
        }
    }

    public override void OnCollisionEnter(Collision collision)
    {
        //死んでいない場合のみ実行
        if (!isDead)
        {
            //弾に当たった場合ダメージをくらう
            if (collision.gameObject.tag == "Bullet")
            {
                sound.PlaySE(transform.position, "hitEnemy");
                //その攻撃で死ぬ場合は死亡アニメーションを再生
                if (this.enemyHp - damage <= 0)
                {
                    anim.SetBool("Dead", true);
                }
                //死なない場合はダメージモーションを再生
                else
                {
                    anim.SetTrigger("Damage");
                }
                Damage(damage);
            }
        }
    }
}
