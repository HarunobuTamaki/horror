using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    bool isPause;

    // Use this for initialization
    void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                isPause = false;
                Time.timeScale = 1f;
                Debug.Log("ポーズじゃない");
            }else
            {
                isPause = true;
                Time.timeScale = 0;
                Debug.Log("ポーズ中");
            }
        }
	}
}
