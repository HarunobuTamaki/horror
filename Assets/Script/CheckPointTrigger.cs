using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CheckPointTrigger : MonoBehaviour {

    protected bool isCheck; //チェックポイント判定
    protected float distance; //Playerとチェックポイントの距離

    public GameObject target; //Playerの子オブジェクトPlayerTarget
    public GameObject nextCheck; //次のチェックポイント
    public Text distanceText; //チェックポイントとの距離を表示

    // Use this for initialization
    protected virtual void Start () {
        isCheck = true;
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
        if (isCheck)
        {
            if (other.gameObject.tag == "Player")
            {
                nextCheck.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
