using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour {

    //enum型で状態管理
    enum gameState{GAME_START,GAME_PLAY,GAME_END};
    gameState battleStatus;

    float timer;

    public GameObject Tutorial; //Tutorialパネル
    public GameObject UIPanel; //UIパネル
    public Text startText; //GameStartテキスト
    public Text overText; //GameOverテキスト
    public Text clearText; //GameClearテキスト
    public Text pressText; //PressSpaceテキスト

    public static bool isGoal; //ゴールフラグ

	// Use this for initialization
	void Start () {
        //ゲームの状態をGAME_STARTに設定
        battleStatus = gameState.GAME_START;
        //startText以外テキスト消去
        startText.enabled = true;
        overText.enabled = false;
        clearText.enabled = false;
        pressText.enabled = false;
        //初期化
        timer = 0;
        isGoal = false;
    }
	
	// Update is called once per frame
	void Update () {
        switch (battleStatus)
        {
            //ゲームが始まった直後の処理
            case gameState.GAME_START:
                StartCoroutine("StartState");
                break;
            //ゲーム中の処理
            case gameState.GAME_PLAY:
                //ゴールに到達するとクリア
                if (isGoal)
                {
                    battleStatus = gameState.GAME_END;
                    clearText.enabled = true;
                }
                //体力が0かウイルス度100%になった場合ゲームオーバー
                if (PlayerController.playerHp <= 0 || PlayerController.virusPercentage >= 100)
                {
                    battleStatus = gameState.GAME_END;
                    overText.enabled = true;
                }
                break;
            //ゲーム終了時の処理
            case gameState.GAME_END:
                //UI等の文字を消去
                UIPanel.SetActive(false);
                if(Tutorial.activeSelf)
                    Tutorial.SetActive(false);
                //一定時間経った場合シーン遷移
                StartCoroutine("EndState");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //タイトルシーンに遷移
                    SceneManager.LoadScene("TitleScene");
                    //動きを再開する
                    Time.timeScale = 1;
                }
                break;
        }

        //Cボタンでチュートリアル表示切替
        if (Input.GetKeyDown(KeyCode.C)){
            if (Tutorial.activeSelf)
            {
                Tutorial.SetActive(false);
            }
            else
            {
                Tutorial.SetActive(true);
            }
        }
	}
    
    IEnumerator StartState()
    {
        //3秒待った後にstartTextを消去
        yield return new WaitForSeconds(3.0f);
        startText.enabled = false;
        battleStatus = gameState.GAME_PLAY;
    }
    
    IEnumerator EndState()
    {
        yield return new WaitForSeconds(3.0f);
        //3秒経過で動きを止める
        Time.timeScale = 0;
        pressText.enabled = true;

    }


 
}
