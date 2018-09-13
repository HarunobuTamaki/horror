using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    GameObject optionPanel;
    GameObject pausePanel;

	// Use this for initialization
	void Start () {
        pausePanel = GameObject.Find("PausePanel");
        optionPanel = GameObject.Find("OptionPanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //Optionボタンを押すとオプション処理
    public void OnClickOptionButton()
    {
        optionPanel.SetActive(true);
        pausePanel.SetActive(false);
    }

    //Backボタンを押すとポーズ中断処理
    public void OnClickBackButton()
    {
        Pause.isPause = false;
        Time.timeScale = 1f;
        Debug.Log("ポーズじゃない");
        Cursor.visible = false;
        pausePanel.SetActive(false);
    }
}
