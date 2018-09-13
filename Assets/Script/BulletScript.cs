using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    
    public static int bulletNumMax = 6; //弾数の最大数
    public GameObject blood; //血液エフェクト
    SoundController sound;//音声コントローラ

	// Use this for initialization
	void Start () {
        sound = GameObject.Find("Player").GetComponent<SoundController>();
        //5秒経過したら消滅する
        Destroy(gameObject, 5.0f);
        
    }
	
	// Update is called once per frame
	void Update () {

        //薬瓶を前進させる
        transform.position += transform.forward * Time.deltaTime * 15;
        

	}

    private void OnCollisionEnter(Collision collision)
    {
        //背景・敵・敵の弾に触れた場合、音を鳴らしてから消滅
        if(collision.gameObject.tag =="Stage" || collision.gameObject.tag =="Enemy" || collision.gameObject.tag == "EnemyBullet")
        {
            Instantiate(blood, transform.position, transform.rotation);
            switch (collision.gameObject.tag)
            {
                case "EnemyBullet":
                    sound.PlaySE(transform.position, "counter");
                    break;

                case "Enemy":
                    sound.PlaySE(transform.position, "hitEnemy");
                    break;
            }
            
            Destroy(gameObject);
        }
    }
}
