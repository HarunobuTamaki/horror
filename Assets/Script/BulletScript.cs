using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    
    public static int bulletNumMax = 6; //弾数の最大数

	// Use this for initialization
	void Start () {
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
        if(collision.gameObject.tag =="Stage" || collision.gameObject.tag =="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
