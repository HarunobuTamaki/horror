using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint1 : CheckPointTrigger {

    public GameObject nextCheck; //次のチェックポイント

    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nextCheck.SetActive(true);
            Destroy(gameObject);
        }
    }
}
