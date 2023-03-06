using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //クリアテキスト
    private GameObject gameClearText;
    // ゲームオーバーテキスト
    private GameObject gameOverText;
    //戻るテキスト
    private GameObject modoruText;
    //ボタンテキスト
    private GameObject buttonText;

    // 走った距離
    private float len = 0;

    // ゲームオーバーの判定
    public bool isGameOver = false;

    //Playerの速度計算に使う変数たち
    Rigidbody2D rigid;
    public Vector2 speed;

    //残り時間
    private GameObject timeText;
    public int countdownMinutes = 3;
    public float countdownSeconds;

    //プレイヤー変数
    private GameObject player;

    //一度だけ実行bool
    bool isCalledOnce1 = false;
    bool isCalledOnce2 = false;
    bool isCalledOnce3 = false;

    // Start is called before the first frame update
    void Start()
    {
        //各種テキストのオブジェクト取得
        this.gameClearText = GameObject.Find("GameClear");
        this.gameOverText = GameObject.Find("GameOver");
        this.modoruText = GameObject.Find("Back_to_the_start");
        this.timeText = GameObject.Find("Time");
        this.buttonText = GameObject.Find("Text");
        //プレイヤー位置関係
        player = GameObject.Find("Player");

        //残り時間:秒
        countdownSeconds = countdownMinutes * 60;

        //速度計算のためrigidbody2D取得
        rigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //sppedにplayerにかかるvelocity代入
        speed = rigid.velocity;

        //距離と時間表示
        if (this.isGameOver == false)
        {
            // 走った距離を更新する
            this.len += this.speed.magnitude * Time.deltaTime;

        }

        if (this.isGameOver == false)
        {
            countdownSeconds -= Time.deltaTime;
            var span = new TimeSpan(0, 0, (int)countdownSeconds);
            timeText.GetComponent<Text>().text = span.ToString(@"mm\:ss");
        }

        if(this.player.transform.position.x <= 350 && !isCalledOnce1)
        {
            isCalledOnce1 = true;
            this.buttonText.GetComponent<Text>().text = "escape";
        }

        if (this.player.transform.position.x >= 350 && !isCalledOnce2)
        {
            isCalledOnce2 = true;
            this.buttonText.GetComponent<Text>().text = "struggle";
        }

        if (this.player.transform.position.x >= 700 && !isCalledOnce3)
        {
            isCalledOnce3 = true;
            this.buttonText.GetComponent<Text>().text = "face";
        }
    }
    public void GameClear()
    {
        // ゲームクリアになったときに、画面上にゲームクリアを表示する
        this.gameClearText.GetComponent<Text>().text = "Game Clear";
        this.isGameOver = true;

        //DelayMethodを2.5秒後に呼び出す
        Invoke("DelayMethod0", 2.5f);

        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 3.5f);
    }

    public void GameOver()
    {
        // ゲームオーバーになったときに、画面上にゲームオーバを表示する
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;

        //DelayMethodを1秒後に呼び出す
        Invoke("DelayMethod0", 1f);

        //DelayMethodを3.5秒後に呼び出す
        Invoke("DelayMethod", 3.5f);
    }

    void DelayMethod0()
    {
        //テキスト表示
        this.modoruText.GetComponent<Text>().text = "Back to the Start.";
    }

    void DelayMethod()
    {
        // クリックされたらシーンをロードする
        if (Input.GetMouseButtonDown(0))
        {
            //SampleSceneを読み込む
            SceneManager.LoadScene("SampleScene");
        }
    }
}
