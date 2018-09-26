using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//タイトル画面メソッド
public class TitleManager : MonoBehaviour {

    bool isPlay; //シーン移行フラグ
    public GameObject endPanel; //終了処理パネル(EndPanel)

	// Use this for initialization
	void Start () {
        isPlay = true;
        endPanel.SetActive(false);
        Cursor.visible = true;
    }
	
	// Update is called once per frame
	void Update () {

        //SpaceKeyを押すと3秒後MainSceneに移行
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endPanel.SetActive(!endPanel.activeSelf);
            
        }

        //パネルが出ていない状態でSpaceキーを押すとMainSceneに遷移する
        if (Input.GetKeyDown(KeyCode.Space) && !endPanel.activeSelf)
        {
            //複数回処理が行われないようフラグで1回きりにする
            if (isPlay)
            {
                GetComponent<AudioSource>().Play();
                StartCoroutine("WaitScene");
                isPlay = false;
            }
        }

        if(Input.GetMouseButtonDown(0) && !endPanel.activeSelf)
        {
            //複数回処理が行われないようフラグで1回きりにする
            if (isPlay)
            {
                GetComponent<AudioSource>().Play();
                StartCoroutine("WaitScene");
                isPlay = false;
            }
        }


    }

    public void OnclickNotEnd()
    {
        endPanel.SetActive(false);
    }

    IEnumerator WaitScene()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("MainScene");
        
    }
}
