using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieTriggerScript : MonoBehaviour {

    //敵オブジェクトを6体生成する
    public GameObject[] zombie = new GameObject[6];

	// Use this for initialization
	void Start () {
        //敵オブジェクトを消しておく
        for(int i = 0; i < zombie.Length; i++)
        {
            zombie[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter(Collider other)
    {
        //Playerオブジェクトに触れると敵オブジェクトを出現させる
        if (other.gameObject.tag == "Player")
        {
            for(int i=0;i<zombie.Length;i++)
            {
                zombie[i].SetActive(true);
            }
        }
    }
}
