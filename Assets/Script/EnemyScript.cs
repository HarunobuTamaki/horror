using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour {

    protected int enemyHp; //enemyの体力
    public int enemyHpMax=50; //enemyの体力最大値
    public int damage=10; //enemyがくらうダメージ量
    public float distance = 0; //PlayerとEnemyの距離
    Vector3 itemPosition; //アイテムの表示位置

    public GameObject target; //PlayerTargetオブジェクト
    public GameObject Vaccine; //ワクチン

	// Use this for initialization
	public virtual void Start () {
        //初期値を体力最大値に設定する
        enemyHp = enemyHpMax;
        //PlayerTargetオブジェクトを指定する
        target = GameObject.Find("PlayerTarget");
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
            Instantiate(Vaccine, itemPosition, transform.rotation);
            AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, transform.position);
            Destroy(gameObject);
        }
    }
}
