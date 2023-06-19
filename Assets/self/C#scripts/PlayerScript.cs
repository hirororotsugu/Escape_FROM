using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Dashボタン押下の判定（ボタンアニメーション予定）
    private bool isDashButtonDown = false;

    //Dashボタン押下の判定（ダッシュ）
    private bool isDashButtonClick = false;

    //Playerを移動させるコンポーネントを入れる
    private Rigidbody2D myRigidbody2D;

    //アニメーションするためのコンポーネントを入れる
    Animator animator;

    //DASHボタン1回の速さ
    Vector2 force = new Vector2(10f, 0f);

    // ゲームクリアになる位置
    private float clearLine = 1000;

    // ゲームオーバーになる時間
    private float deadLine = 0;

    //UIController取得したいときのやつ
    private GameObject uicon;
    UIController uiconcon;


    // Start is called before the first frame update
    void Start()
    {
        // アニメータのコンポーネントを取得する
        this.animator = GetComponent<Animator>();
        //Rigidbodyコンポーネントを取得
        this.myRigidbody2D = GetComponent<Rigidbody2D>();

        //一旦ダッシュアニメーション切る
        animator.SetFloat("dashspeed", 0);

        //速度取得のためUIControllerを取得
        uicon = GameObject.Find("Canvas");
        uiconcon = uicon.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
            if (this.isDashButtonClick)
            {
                //Playerに速度を与える&ダッシュアニメーションする
                myRigidbody2D.AddForce(force);
                this.isDashButtonClick = false;
            }

        float dashspeed = uiconcon.speed.magnitude;
        animator.SetFloat("dashspeed", dashspeed);

        // クリアラインを超えた場合ゲームクリアにする
        if (transform.position.x > this.clearLine)
        {
            // UIControllerのGameClear関数を呼び出して画面上に「GameClear」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameClear();

            //消滅アニメーションboolをtrue
            this.animator.SetBool("vanish", true);

            //速度0
            this.myRigidbody2D.velocity = Vector2.zero;
        }

        // デッドラインを超えた場合ゲームオーバーにする
        if (uiconcon.countdownSeconds <= deadLine)
        {
            // UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //消滅アニメーションboolをtrue
            this.animator.SetBool("vanish", true);

            //速度0
            this.myRigidbody2D.velocity = Vector2.zero;
        }
    }

    //Dashボタンを押して離した場合の処理（ダッシュ）
    public void GetDashButtonClick()
    {
        if (uiconcon.isGameOver == false)
        {
            this.isDashButtonClick = true;
            Debug.Log("Dash押して離した（ダッシュ）");
        }
    }

    //Dashボタンを押した場合の処理（ボタンアニメーション予定）
    public void GetDashButtonDown()
    {
        this.isDashButtonDown = true;
        Debug.Log("Dash押下（ボタンアニメーション予定）");
    }
    //Dashボタンを離した場合の処理（ボタンアニメーション予定）
    public void GetDashButtonUp()
    {
        this.isDashButtonDown = false;
        Debug.Log("Dash離す（ボタンアニメーション予定）");
    }
    
}
