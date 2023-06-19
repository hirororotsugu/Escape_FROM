using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //�N���A�e�L�X�g
    private GameObject gameClearText;
    // �Q�[���I�[�o�[�e�L�X�g
    private GameObject gameOverText;
    //�߂�e�L�X�g
    private GameObject modoruText;
    //�{�^���e�L�X�g
    private GameObject buttonText;

    // ����������
    private float len = 0;

    // �Q�[���I�[�o�[�̔���
    public bool isGameOver = false;

    //Player�̑��x�v�Z�Ɏg���ϐ�����
    Rigidbody2D rigid;
    public Vector2 speed;

    //�c�莞��
    private GameObject timeText;
    public int countdownMinutes = 3;
    public float countdownSeconds;

    //�v���C���[�ϐ�
    private GameObject player;

    //��x�������sbool
    bool isCalledOnce1 = false;
    bool isCalledOnce2 = false;
    bool isCalledOnce3 = false;

    // Start is called before the first frame update
    void Start()
    {
        //�e��e�L�X�g�̃I�u�W�F�N�g�擾
        this.gameClearText = GameObject.Find("GameClear");
        this.gameOverText = GameObject.Find("GameOver");
        this.modoruText = GameObject.Find("Back_to_the_start");
        this.timeText = GameObject.Find("Time");
        this.buttonText = GameObject.Find("Text");
        //�v���C���[�ʒu�֌W
        player = GameObject.Find("Player");

        //�c�莞��:�b
        countdownSeconds = countdownMinutes * 60;

        //���x�v�Z�̂���rigidbody2D�擾
        rigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //spped��player�ɂ�����velocity���
        speed = rigid.velocity;

        //�����Ǝ��ԕ\��
        if (this.isGameOver == false)
        {
            // �������������X�V����
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
        // �Q�[���N���A�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���N���A��\������
        this.gameClearText.GetComponent<Text>().text = "Game Clear";
        this.isGameOver = true;

        //DelayMethod��2.5�b��ɌĂяo��
        Invoke("DelayMethod0", 2.5f);

        //DelayMethod��3.5�b��ɌĂяo��
        Invoke("DelayMethod", 3.5f);
    }

    public void GameOver()
    {
        // �Q�[���I�[�o�[�ɂȂ����Ƃ��ɁA��ʏ�ɃQ�[���I�[�o��\������
        this.gameOverText.GetComponent<Text>().text = "Game Over";
        this.isGameOver = true;

        //DelayMethod��1�b��ɌĂяo��
        Invoke("DelayMethod0", 1f);

        //DelayMethod��3.5�b��ɌĂяo��
        Invoke("DelayMethod", 3.5f);
    }

    void DelayMethod0()
    {
        //�e�L�X�g�\��
        this.modoruText.GetComponent<Text>().text = "Back to the Start.";
    }

    void DelayMethod()
    {
        // �N���b�N���ꂽ��V�[�������[�h����
        if (Input.GetMouseButtonDown(0))
        {
            //SampleScene��ǂݍ���
            SceneManager.LoadScene("SampleScene");
        }
    }
}
