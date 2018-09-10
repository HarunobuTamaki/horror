using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour {

    bool isTrigger; //トリガーフラグ
    public GameObject zombie; //敵オブジェクト
    Vector3 triggerPos; //出現位置

    // Use this for initialization
    void Start () {
        //出現位置を生成する
        isTrigger = false;
        triggerPos.x = transform.position.x;
        triggerPos.y = transform.position.y - 0.68f;
        triggerPos.z = transform.position.z - 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        //Playerオブジェクトに触れると敵生成(1度きりの為フラグ設定)
        if (other.gameObject.tag == "Player" && !isTrigger)
        {
            Instantiate(zombie, triggerPos,
                transform.rotation);
            isTrigger = true;
        }
    }
}
