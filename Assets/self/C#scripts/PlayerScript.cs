using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    //Dash�{�^�������̔���i�{�^���A�j���[�V�����\��j
    private bool isDashButtonDown = false;

    //Dash�{�^�������̔���i�_�b�V���j
    private bool isDashButtonClick = false;

    //Player���ړ�������R���|�[�l���g������
    private Rigidbody2D myRigidbody2D;

    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    Animator animator;

    //DASH�{�^��1��̑���
    Vector2 force = new Vector2(10f, 0f);

    // �Q�[���N���A�ɂȂ�ʒu
    private float clearLine = 1000;

    // �Q�[���I�[�o�[�ɂȂ鎞��
    private float deadLine = 0;

    //UIController�擾�������Ƃ��̂��
    private GameObject uicon;
    UIController uiconcon;


    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�̃R���|�[�l���g���擾����
        this.animator = GetComponent<Animator>();
        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody2D = GetComponent<Rigidbody2D>();

        //��U�_�b�V���A�j���[�V�����؂�
        animator.SetFloat("dashspeed", 0);

        //���x�擾�̂���UIController���擾
        uicon = GameObject.Find("Canvas");
        uiconcon = uicon.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
            if (this.isDashButtonClick)
            {
                //Player�ɑ��x��^����&�_�b�V���A�j���[�V��������
                myRigidbody2D.AddForce(force);
                this.isDashButtonClick = false;
            }

        float dashspeed = uiconcon.speed.magnitude;
        animator.SetFloat("dashspeed", dashspeed);

        // �N���A���C���𒴂����ꍇ�Q�[���N���A�ɂ���
        if (transform.position.x > this.clearLine)
        {
            // UIController��GameClear�֐����Ăяo���ĉ�ʏ�ɁuGameClear�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameClear();

            //���ŃA�j���[�V����bool��true
            this.animator.SetBool("vanish", true);

            //���x0
            this.myRigidbody2D.velocity = Vector2.zero;
        }

        // �f�b�h���C���𒴂����ꍇ�Q�[���I�[�o�[�ɂ���
        if (uiconcon.countdownSeconds <= deadLine)
        {
            // UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();

            //���ŃA�j���[�V����bool��true
            this.animator.SetBool("vanish", true);

            //���x0
            this.myRigidbody2D.velocity = Vector2.zero;
        }
    }

    //Dash�{�^���������ė������ꍇ�̏����i�_�b�V���j
    public void GetDashButtonClick()
    {
        if (uiconcon.isGameOver == false)
        {
            this.isDashButtonClick = true;
            Debug.Log("Dash�����ė������i�_�b�V���j");
        }
    }

    //Dash�{�^�����������ꍇ�̏����i�{�^���A�j���[�V�����\��j
    public void GetDashButtonDown()
    {
        this.isDashButtonDown = true;
        Debug.Log("Dash�����i�{�^���A�j���[�V�����\��j");
    }
    //Dash�{�^���𗣂����ꍇ�̏����i�{�^���A�j���[�V�����\��j
    public void GetDashButtonUp()
    {
        this.isDashButtonDown = false;
        Debug.Log("Dash�����i�{�^���A�j���[�V�����\��j");
    }
    
}
