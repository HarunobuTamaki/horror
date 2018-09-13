using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class PlayerController : MonoBehaviour {

    public static int playerHp; //PlayerのHP
    public int playerHpMax = 1000; //PlayerのHP最大値
    int bulletNum; //弾数
    int bulletNumMax; //弾数の最大値
    float reloadTimer = 0; //リロードタイマー
    float virusTimer = 0; //ウイルスタイマー
    public static int virusPercentage = 0; //ウイルス度
    int damage = 50; //くらうダメージ量
    bool isInvincible; //無敵時間フラグ

    public GameObject bullet; //銃弾(瓶)
    public GameObject muzzle; //発射位置
    public Image reloadGauge; //リロードゲージ
    public Image playerImg; //中央下部のPlayer画像
    public Text reloadText; //リロードテキスト
    public Text hpText; //HP表示部分
    public Text bulletText; //残り銃弾数
    public Text virusText; //ウイルス度テキスト

    AudioSource audioSource;//SE再生用AudioSource
    SoundController sound;//音声コントローラ

    // Use this for initialization
    void Start () {
        //初期化
        playerHp = playerHpMax;
        bulletNumMax = BulletScript.bulletNumMax;
        bulletNum = bulletNumMax;
        reloadGauge.enabled = false;
        reloadText.enabled = false;
        isInvincible = false;
        //AudioSourceの取得
        audioSource = GetComponent<AudioSource>();
        //音声コントローラを取得
        sound = GetComponent<SoundController>();
        sound.PlayBGM("stage");
        
    }
	
	// Update is called once per frame
	void Update () {
        //5秒毎にウイルス度が1ずつ上がる
        virusTimer += Time.deltaTime;
        if (virusTimer > 5.0f)
        {
            virusPercentage++;
            virusTimer = 0;
        }

        //マウス左クリックで射撃
        if (Input.GetMouseButtonDown(0) && bulletNum>0 && !Pause.isPause)
        {
            sound.PlaySE(audioSource, "fire");
            Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
            bulletNum--;

        }

        //リロードに移行するため弾数を0にする
        if (Input.GetKeyDown(KeyCode.R))
            bulletNum = 0;

        //弾数がなくなるかリロードボタンを押したらリロード
        if (bulletNum <= 0)
        {
            //リロード開始時に一度だけリロード音再生
            if (!reloadText.enabled)
            {
                sound.PlaySE(audioSource, "reload");
            }
            //ゲージとテキストを表示
            reloadGauge.enabled= true;
            reloadText.enabled= true;
            //リロード中テキストを点滅させる
            reloadText.color = new Color
                (1, 0, 0, Mathf.PingPong(Time.time,1.0f));
            //リロード中ゲージを伸ばす
            reloadGauge.transform.localScale = new Vector3
                (reloadTimer / 2.0f, 1, 1);
            reloadTimer += Time.deltaTime;

            //2秒経つとリロード終了
            if (reloadTimer > 2.0f)
            {
                //リロード完了音再生
                sound.PlaySE(audioSource, "reloadOver");
                //リロード処理
                bulletNum = bulletNumMax;
                reloadTimer = 0;
                reloadText.enabled = false;
                reloadGauge.enabled = false;
            }

        }
        
        bulletNum = Mathf.Clamp(bulletNum, 0, bulletNumMax);
        Camera.main.GetComponent<NoiseAndGrain>().enabled = true;

        //テキスト表示
        hpText.GetComponent<Text>().text =
            string.Format("{0:0000}/{1:0000}",playerHp,playerHpMax);
        bulletText.GetComponent<Text>().text =
            string.Format("{0}/{1}", bulletNum, bulletNumMax);
        virusText.GetComponent<Text>().text =
            string.Format("{0}%",virusPercentage);
        


    }

    //無敵時間中の処理
    IEnumerator InvincibleManager()
    {
        int count = 5;
        isInvincible = true;
        //count秒の処理
        while (count > 0)
        {
            //1秒毎の処理
            playerImg.color =
                new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.25f);
            playerImg.color =
                new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            playerImg.color =
               new Color(1, 1, 1, 0);
            yield return new WaitForSeconds(0.25f);
            playerImg.color =
                new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.25f);
            count--;
        }
        //ループ処理を抜けて色を元通りにする
        playerImg.color =Color.white;
        isInvincible = false;
        
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        //敵に当たった時か攻撃された時の処理
        if (!isInvincible)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                sound.PlaySE(audioSource, "die");
                playerHp -= damage;
                playerHp = Mathf.Clamp(playerHp, 0, playerHpMax);
                virusPercentage += 2;
                virusPercentage = Mathf.Clamp(virusPercentage, 0, 100);
                StartCoroutine("InvincibleManager");
            }

            if (collision.gameObject.tag == "EnemyBullet" || collision.gameObject.tag == "SpiderBullet")
            {
                sound.PlaySE(audioSource, "die");
                playerHp -= damage;
                playerHp = Mathf.Clamp(playerHp, 0, playerHpMax);
                virusPercentage += 5;
                virusPercentage = Mathf.Clamp(virusPercentage, 0, 100);
                StartCoroutine("InvincibleManager");
            }
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        //アイテムとった時の処理
        if (other.gameObject.tag == "Vaccine")
        {
            Destroy(other.gameObject);
            playerHp += 50;
            virusPercentage -= 10;
            playerHp = Mathf.Clamp(playerHp, 0, playerHpMax);
            virusPercentage = Mathf.Clamp(virusPercentage, 0, 100);
            sound.PlaySE(audioSource, "getItem");
        }
    }
}
