using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour {

    Image marker; //コンパス上に表示するマーカー
    public Image markerImage; //マーカーオブジェクト
    GameObject compass; //コンパスオブジェクト

    GameObject target; //Playerの位置オブジェクト


	// Use this for initialization
	void Start () {
        //targetにPlayerTargetオブジェクトを指定
        target = GameObject.Find("PlayerTarget");
        
        //マーカーをレーダー(コンパス)上に表示する
        compass = GameObject.Find("CompassMask");
        //マーカーを生成するコンパスの位置に生成
        marker = Instantiate(markerImage, 
            compass.transform.position, Quaternion.identity) as Image;
        //コンパスの子オブジェクトして生成
        marker.transform.SetParent(compass.transform, false);
	}
	
	// Update is called once per frame
	void Update () {

        //マーカーをプレイヤーの相対位置に配置する
        Vector3 position = transform.position - target.transform.position;
        //2次元表示するため、xとzでマーカーの座標をとる
        marker.transform.localPosition = new Vector3
            (position.x, position.z, 0);
	}

    //アタッチしたオブジェクトが消滅するとマーカーも消滅する
    private void OnDestroy()
    {
        Destroy(marker);
    }
}
