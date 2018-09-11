using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CheckPointTrigger : MonoBehaviour {
    
    protected float distance; //Playerとチェックポイントの距離

    protected GameObject target; //Playerの子オブジェクトPlayerTarget
    protected GameObject distanceText; //チェックポイントとの距離を表示

    // Use this for initialization
    protected virtual void Start () {
        distanceText = GameObject.Find("Distance");
        target = GameObject.Find("PlayerTarget");
	}
	
	// Update is called once per frame
	protected virtual void Update () {
        //Playerとチェックポイントとの距離を測る
        distance = Vector3.Distance(target.transform.position, transform.position);
        //相対位置を取る
        Vector3 position = transform.position - target.transform.position;
        //距離を絶対数で取る
        distance = Mathf.Abs(distance);
        //距離を小数点2桁以下で表示
        distanceText.GetComponent<Text>().text =
            distance.ToString("F2");
	}

    protected virtual void OnTriggerEnter(Collider other)
    {

    }
}
