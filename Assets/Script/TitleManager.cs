using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    //タイトル画面メソッド

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //SpaceKeyを押すと3秒後MainSceneに移行
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<AudioSource>().Play();
            StartCoroutine("WaitScene");
        }
	}

    IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainScene");
        
    }
}
