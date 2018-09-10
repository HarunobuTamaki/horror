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
        
        //EnemyのHPが0になるとオブジェクトが破棄されてワクチンを生成する
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
            Instantiate(Vaccine, itemPosition, transform.rotation);
            GetComponent<AudioSource>().Play();
        }
        
    }

    public virtual void Attack()
    {

    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        //弾に当たった場合ダメージをくらう
        if(collision.gameObject.tag == "Bullet")
        {
            enemyHp -= damage;
            enemyHp = Mathf.Clamp(enemyHp,0,enemyHpMax);
        }
    }
}
