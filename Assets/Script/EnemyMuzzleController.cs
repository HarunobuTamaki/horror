using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMuzzleController : MonoBehaviour {//親となるEnemyの代わりにY軸方向へ向いてくれる砲台オブジェクト
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    //親オブジェクトから呼び出す用のLookAtメソッド
    public void ILookAt(Transform target)
    {
        transform.LookAt(target);
    }
}
