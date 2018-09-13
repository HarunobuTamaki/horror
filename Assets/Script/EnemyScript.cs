using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour {

    protected int enemyHp; //enemyの体力
    public int enemyHpMax=50; //enemyの体力最大値
    public int damage=10; //enemyがくらうダメージ量
    public float distance = 0; //PlayerとEnemyの距離
    public float deathDelay = 0;//死亡時ディレイ(死んでから消滅するまでの待機時間)
    public string enemyCode = "zombie_man";//敵キャラクターの種別
    Vector3 itemPosition; //アイテムの表示位置

    public bool isDead;//死亡判別フラグ

    public GameObject target; //PlayerTargetオブジェクト
    public GameObject Vaccine; //ワクチン

    protected enum EnemyType { zombie_man, zombie_woman, littleSpider, bigSpider};//敵キャラの種別

    protected AudioSource selfAudioSource;//自身のAudioSource
    protected AudioSource playerAudioSource;//プレイヤーのAudioSource
    protected SoundController sound;//音声コントローラ

	// Use this for initialization
	public virtual void Start () {
        //初期値を体力最大値に設定する
        enemyHp = enemyHpMax;
        //PlayerTargetオブジェクトを指定する
        target = GameObject.Find("PlayerTarget");
        //自身のAudioSourceを取得
        selfAudioSource = GetComponent<AudioSource>();
        //音声コントローラを指定する
        GameObject player = GameObject.Find("Player");
        playerAudioSource = player.GetComponent<AudioSource>();
        sound = player.GetComponent<SoundController>();
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
        //死んでいない場合のみ実行
        if (!isDead)
        {
            //弾に当たった場合ダメージをくらう
            if (collision.gameObject.tag == "Bullet")
            {
                sound.PlaySE(playerAudioSource, "hitEnemy");
                Damage(damage);
            }
        }
    }

    public void LookAt2D()//targetに向かったY軸回転だけを行うメソッド
    {
        //「相手と同じ位置と奥行き」、「自分と同じ高さ」の座標を取得
        Vector3 targetPos2D = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
        //↑に向かってLookAt
        transform.LookAt(targetPos2D);
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
                sound.PlaySE(selfAudioSource, "attackZombie_man");
                break;
            //女ゾンビ攻撃時
            case 1:
                sound.PlaySE(selfAudioSource, "attackZombie_woman");
                break;

            //小グモ攻撃時
            case 2:
                sound.PlaySE(selfAudioSource, "attackLittleSpider");
                break;

            //大グモ攻撃時
            case 3:
                sound.PlaySE(selfAudioSource, "attackBigSpider");
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
                sound.PlaySE(selfAudioSource,"dieingZombie");
                break;
            //女ゾンビ死亡時
            case 1:
                goto case 0;

            //小グモ死亡時
            case 2:
                sound.PlaySE(selfAudioSource, "dieingLittleSpider");
                break;

            //大グモ死亡時
            case 3:
                sound.PlaySE(selfAudioSource, "dieingBigSpider");
                break;
        }

        //ワクチンを生成してオブジェクトを破棄
        StartCoroutine(Zanshin(deathDelay));
    }
    //死亡時ディレイ秒後にワクチン生成・オブジェクトを消滅させるコルーチン
    IEnumerator Zanshin(float second)
    {
        //死亡判別フラグをオン
        isDead = true;
        //待機・ワクチン生成・消滅処理
        yield return new WaitForSeconds(second);
        Instantiate(Vaccine, itemPosition, transform.rotation);
        Destroy(gameObject);
    }
}
