using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContoroller : MonoBehaviour {

    //Item側の処理

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter(Collider other)
    {
        //Playerタグのオブジェクトに触れると消去
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
