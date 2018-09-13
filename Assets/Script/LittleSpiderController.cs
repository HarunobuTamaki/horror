using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleSpiderController : EnemyScript
{

    public GameObject spiderBullet;
    public GameObject MuzzlePrefub;//弾発射の基点になる子オブジェクト

    GameObject Muzzle;//prefubから生成した子オブジェクトの情報
    EnemyMuzzleController ctr;//子オブジェクトから取得したコントローラ
    public float MuzzleMarginY;//子オブジェクト生成時のY軸方向マージン
        
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
        //marginを加算した位置に子オブジェクトを生成、情報を取得
        Vector3 margin = new Vector3(0,MuzzleMarginY,0);
        Muzzle = Instantiate(MuzzlePrefub, transform.position + margin, transform.rotation);
        Muzzle.transform.parent = transform;
        ctr = Muzzle.GetComponent<EnemyMuzzleController>();
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
                //自分はY軸回転だけ
                LookAt2D();
                //子オブジェクトはふつうにLookAt
                ctr.ILookAt(target.transform);
                //2.5秒間隔で射撃
                if (spanTimer > 2.5f)
                {
                    //攻撃モーション再生
                    anim.SetTrigger("Attack");
                    //おたけび再生
                    howl(enemyCode);
                    //子オブジェクトの位置・回転を基点に弾を射出
                    Instantiate(spiderBullet, Muzzle.transform.position, Muzzle.transform.rotation);
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
