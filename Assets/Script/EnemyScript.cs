using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour {

    protected int enemyHp; //enemyの体力
    public int enemyHpMax=50; //enemyの体力最大値
    public int damage=10; //enemyがくらうダメージ量
    public float distance = 0; //PlayerとEnemyの距離
    public string enemyCode = "zombie_man";//敵キャラクターの種別
    Vector3 itemPosition; //アイテムの表示位置

    public GameObject target; //PlayerTargetオブジェクト
    public GameObject Vaccine; //ワクチン

    protected enum EnemyType { zombie_man, zombie_woman, littleSpider, bigSpider};//敵キャラの種別

    SoundController sound;//音声コントローラ

	// Use this for initialization
	public virtual void Start () {
        //初期値を体力最大値に設定する
        enemyHp = enemyHpMax;
        //PlayerTargetオブジェクトを指定する
        target = GameObject.Find("PlayerTarget");
        //音声コントローラを指定する
        sound = GameObject.Find("Player").GetComponent<SoundController>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
        //アイテムの出現位置
        itemPosition = new Vector3(transform.position.x, 1, transform.position.z);

        //EnemyとPlayerの距離
        distance = Vector3.Distance(target.transform.position, transform.position);
    }

    public virtual void Attack()
    {
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        //弾に当たった場合ダメージをくらう
        if(collision.gameObject.tag == "Bullet")
        {
            sound.PlaySE(transform.position, "hitEnemy");
            Damage(damage);
        }

    }

    public void Damage(int damage)//被ダメージ時の処理
    {
        //引数で渡された分のダメージをHpから引く
        enemyHp -= damage;
        enemyHp = Mathf.Clamp(enemyHp, 0, enemyHpMax);

        //EnemyのHPが0になった場合、オブジェクトが破棄されてワクチンを生成する
        if (enemyHp <= 0)
        {
            Die(enemyCode);
        }
    }

    public void howl(string code)//攻撃時のおたけび
    {
        int type = (int)Enum.Parse(typeof(EnemyType), code);//敵タイプをintに変換

        //攻撃音声を再生
        switch (type)
        {
            //男ゾンビ攻撃時
            case 0:
                sound.PlaySE(transform.position, "attackZombie_man");
                break;
            //女ゾンビ攻撃時
            case 1:
                sound.PlaySE(transform.position, "attackZombie_woman");
                break;

            //小グモ攻撃時
            case 2:
                sound.PlaySE(transform.position, "attackLittleSpider");
                break;

            //大グモ攻撃時
            case 3:
                sound.PlaySE(transform.position, "attackBigSpider");
                break;
        }
    }

    public void Die(string code)
    {
        int type = (int)Enum.Parse(typeof(EnemyType), code);

        //やられ音声を再生
        switch (type)
        {
            //男ゾンビ死亡時
            case 0:
                sound.PlaySE(transform.position,"dieingZombie");
                break;
            //女ゾンビ死亡時
            case 1:
                goto case 0;

            //小グモ死亡時
            case 2:
                sound.PlaySE(transform.position, "dieingLittleSpider");
                break;

            //大グモ死亡時
            case 3:
                sound.PlaySE(transform.position, "dieingBigSpider");
                break;
        }

        //ワクチンを生成してオブジェクトを破棄
        Instantiate(Vaccine, itemPosition, transform.rotation);
        Destroy(gameObject);
    }
}
