using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    attackZombie_man,   //5：男ゾンビ攻撃時
    attackZombie_woman, //6：女ゾンビ攻撃時
    attackLittleSpider, //7：クモ攻撃時
    dieingZombie,       //8：ゾンビ死亡時
    dieingLittleSpider, //9：クモ死亡時
    dieingBigSpider,    //10：大グモ死亡時
    hitEnemy,           //11：プレイヤーの攻撃ヒット時
}

public class SoundController : MonoBehaviour {
    AudioSource BGMChannel;//BGM再生用AudioSource
    public AudioClip[] Musics = new AudioClip[5];//BGMの格納用配列
    public AudioClip[] Sounds = new AudioClip[12];//SEの格納用配列。使用するSEは全てここに入れる

    // Use this for initialization
    void Start ()
    {
        //AudioSource格納用変数にMainCameraが持つAudioSourceを取得
        BGMChannel = GameObject.Find("MainCamera").GetComponent<AudioSource>();
        Debug.Log(BGMChannel);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    //BGM再生(MainCameraが持つAudioSourceから第2引数のBGMを再生)
    public void PlayBGM(string index)
    {
        int code = (int)Enum.Parse(typeof(BGMList), index);
        BGMChannel.clip = Musics[code];
        BGMChannel.Play();
    }

    //BGM停止(いちおう)
    public void StopBGM()
    {
        BGMChannel.Stop();
    }

    //SE再生(第1引数の座標に第2引数の音を鳴らすオブジェクトを生成)
    public void PlaySE(Vector3 pos, string index)
    {
        int code = (int)Enum.Parse(typeof(SEList),index);

        AudioSource.PlayClipAtPoint(Sounds[code], pos);
    }
    
}
