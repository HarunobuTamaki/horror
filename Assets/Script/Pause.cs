using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {

    public static bool isPause;
    public GameObject optionPanel;
    public GameObject pausePanel;

    // Use this for initialization
    void Start () {
        isPause = false;
        optionPanel.SetActive(false);
        pausePanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isPause)
            {
                PauseInactive();
            }
            else
            {
                PauseActive();
            }
            
        }
	}

    //ポーズ処理
    void PauseActive()
    {
        isPause = true;
        Time.timeScale = 0;
        Debug.Log("ポーズ中");
        Cursor.visible = true;
        pausePanel.SetActive(true);
    }
    //ポーズ中断処理
    void PauseInactive()
    {
        isPause = false;
        Time.timeScale = 1f;
        Debug.Log("ポーズじゃない");
        Cursor.visible = false;
        pausePanel.SetActive(false);
        if (optionPanel.activeSelf)
        {
            optionPanel.SetActive(false);
        }
    }
    
}
