using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy_Mini : MonoBehaviour
{
    [Header("HP")]
    public float HP;

    [Header("�ړ����x")]
    public float Speed;

    [Header("�U�����x")]
    public float AttackSpeed;

    [Header("�ړ����x")]
    public float MoveSpeed;

    [Header("�ʒu")]
    public Vector2 Position;

    /// <summary>
    /// �����ԍ�
    /// </summary>
    [SerializeField]
    int Enemy_No;

    [SerializeField,Header("�G�̍U����")]
    public float Power;

    /// <summary>
    /// �U�����L���X�g
    /// </summary>
    [SerializeField]
    float Attack_ReTime;

    float ReTime;

    /// <summary>
    /// player�X�N���v�g
    /// </summary>
    [SerializeField]
    PlayerData playerData;

    public int GetEnemy_No
    {
        get { return Enemy_No; }
    }

    /// <summary>
    /// �ړ��^�C�v
    /// </summary>
    public enum Enemy_MoveType
    {
        /// <summary>
        /// �ړ��Ȃ�
        /// </summary>
        Stop,

        /// <summary>
        /// �ҋ@�ꏊ�܂ňړ�
        /// </summary>
        Move_StopAria,

        /// <summary>
        /// playe�ɑ̓�����
        /// </summary>
        player_Attack,
    }

    [SerializeField]
    Enemy_MoveType MoveType;

    public enum Enemy_Type
    {
        Type1,
        Type2,
        Type3,
        Type4,
    }
    [Header("�G�̎��")]
    public Enemy_Type EnemyType;


    [Header("�G�̉摜")]
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;
    public Sprite Enemy4;

    //�ړ��O�ʒu
    private Vector2 StartPosition;
    //�ړ���ʒu
    private Vector2 MovePosition;

    private void Update()
    {
        // �ړ�
        MoveUpdate();


    }

    public void SetMoveType(Enemy_MoveType type,float speed,bool flg)
    {
        MoveType=type;
        Speed = speed;

        switch (MoveType)
        {
            case Enemy_MoveType.Stop:
                {

                }
                break;
            case Enemy_MoveType.Move_StopAria:
                {

                    MovePosition = new Vector2(Random.Range(0.0f, -6f), StartPosition.y);
                    break;
                }
            case Enemy_MoveType.player_Attack:
                {
                    StartPosition = transform.position;
                    MovePosition = new Vector2(5.7f,0);
                    break;
                }

        }

    }

    /// <summary>
    /// �ړ��X�V
    /// </summary>
    private void MoveUpdate()
    {

        switch (MoveType)
        {
            case Enemy_MoveType.Stop:
                {
                    if (GameManager.Instance.IsGetTime_flg)
                    {
                        ReTime += Time.deltaTime;
                    }

                    //�U������
                    if (Attack_ReTime <= ReTime)
                    {
                        SetMoveType(Enemy_MoveType.player_Attack, AttackSpeed, true);

                        ReTime = 0.0f;
                    }
                }
                break;
            case Enemy_MoveType.Move_StopAria:
                {
                    float speed = Speed * Time.deltaTime;
                    if (!GameManager.Instance.GetGameOperationFlg)
                    {
                        speed = 0;
                    }

                    transform.position = Vector2.MoveTowards(transform.position, MovePosition, speed);

                    //�ڕW�ɓ��B������
                    float subn1 = transform.position.x - MovePosition.x;
                    if (Mathf.Abs(subn1) <= 0.01f)
                    {
                        SetMoveType(Enemy_MoveType.Stop, 0, false);
                    }
                    break;
                }

            case Enemy_MoveType.player_Attack:
                {
                    float speed = Speed * Time.deltaTime;
                    if (!GameManager.Instance.GetGameOperationFlg)
                    {
                        speed = 0;
                    }
                    transform.position = Vector2.MoveTowards(transform.position, MovePosition, speed);

                    //�ڕW�ɓ��B������
                    float subn = transform.position.x - MovePosition.x;
                    if (Mathf.Abs(subn) <= 0.1f)
                    {
                        SetMoveType(Enemy_MoveType.Move_StopAria, AttackSpeed, false);

                        //�U��
                        playerData.Damage(Power);
                    }

                    break;
                }
        }
    }


    /// <summary>
    /// �_���[�W���󂯂�
    /// </summary>
    /// <param name="damage">�_���[�W</param>
    /// <returns>�|������</returns>
    public bool Damage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            gameObject.SetActive(false);
            return true;
        }

        return false;
    }

    /// <summary>
    /// �G�J�n
    /// </summary>
    /// <param name="no">�����ԍ�</param>
    /// <param name="hp">HP</param>
    /// <param name="type">�摜���</param>
    public void SetStart(int no,float hp, Enemy_Type type)
    {
        Enemy_No = no;
        HP = hp;
        StartPosition = new Vector2(-11, Random.Range(1.7f, -3.5f));
        SetMoveType(Enemy_MoveType.Move_StopAria, MoveSpeed, false);
        transform.position = StartPosition;

        switch (type)
        {
            case Enemy_Type.Type1:
                GetComponent<SpriteRenderer>().sprite = Enemy1;
                break;
            case Enemy_Type.Type2:
                GetComponent<SpriteRenderer>().sprite = Enemy2;
                break;
            case Enemy_Type.Type3:
                GetComponent<SpriteRenderer>().sprite = Enemy3;
                break;
            case Enemy_Type.Type4:
                GetComponent<SpriteRenderer>().sprite = Enemy4;
                break;
        }

        //    pos = StartPosition;
        //    Type = EnemyType;
        //    EnemyPower = Power;
    }

}
