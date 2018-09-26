using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour {

    GameObject optionPanel; //Optionパネル
    GameObject pausePanel; //Pauseパネル
    GameObject endPanel; //endパネル

	// Use this for initialization
	void Start () {
        pausePanel = GameObject.Find("PausePanel");
        optionPanel = GameObject.Find("OptionPanel");
        endPanel = GameObject.Find("EndPanel");
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

    //BacktoDeskTopButtonを押すとゲーム終了パネルを開く
    public void OnClickBackToDeskTop()
    {
        endPanel.SetActive(true);
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

    //EndPanelで「いいえ」を押すとendPanelを閉じる
    public void NotEndGame()
    {
        endPanel.SetActive(false);
        pausePanel.SetActive(true);
    }
}
