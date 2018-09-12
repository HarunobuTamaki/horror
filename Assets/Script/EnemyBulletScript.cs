using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBulletScript : MonoBehaviour {
    

	// Use this for initialization
	public virtual void Start () {
        //3秒経過したら消滅する
        Destroy(gameObject, 3.0f);
	}
	
	// Update is called once per frame
	public virtual void Update () {
        //向いている方向に進む
        transform.position += transform.forward * Time.deltaTime * 5f;
	}

    public virtual void OnCollisionEnter(Collision collision)
    {
        //Stageタグ、Playerタグオブジェクト、Playerの弾に触れると消滅
        if (collision.gameObject.tag == "Stage" || collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}
