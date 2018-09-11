using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
    AudioSource BGMChannel;//BGM再生用AudioSource
    public AudioClip[] Musics = new AudioClip[5];//BGMの格納用配列
    public AudioClip[] Sounds = new AudioClip[11];//SEの格納用配列。使用するSEは全てここに入れる

    public enum BGMList//BGMはこの列挙型で指定する
    {
        title,              //0：タイトル
        stage,              //1：ゲーム画面
        boss,               //2：ボス登場時
        clear,              //3：ゲームクリア時
        gameover,           //4：ゲームオーバー時
    }

    public enum SEList//SEはこの列挙型で指定する
    {
        footStep,           //0：足音
        dash,               //1：スプリント時足音
        fire,               //2：攻撃発射時
        getItem,            //3：アイテム取得時
        die,                //4：プレイヤー死亡時
        attackMaleZonbie,   //5：男ゾンビ攻撃時
        attackFemaleZonbie, //6：女ゾンビ攻撃時
        attackSpider,       //7：クモ攻撃時
        dieingZonbie,       //8：ゾンビ死亡時
        dieineSpider,       //9：クモ死亡時
        dieingBigSpider,    //10：大グモ死亡時

    } 
    // Use this for initialization
    void Start ()
    {
        //AudioSource格納用変数にMainCameraが持つAudioSourceを取得
        BGMChannel = GameObject.Find("MainCamera").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //BGM再生(MainCameraが持つAudioSourceから第2引数のBGMを再生)
    public void PlayBGM(int index)
    {
        BGMChannel.clip = Musics[index];
        BGMChannel.Play();
    }

    //BGM停止(いちおう)
    public void StopBGM()
    {
        BGMChannel.Stop();
    }

    //SE再生(第1引数の座標に第2引数の音を鳴らすオブジェクトを生成)
    public void PlaySE(Vector3 pos, int index)
    {
        AudioSource.PlayClipAtPoint(Sounds[index], pos);
    }
    
}
