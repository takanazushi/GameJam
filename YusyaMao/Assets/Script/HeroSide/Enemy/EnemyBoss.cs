using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyBoss : MonoBehaviour
{

    [SerializeField,Header("HP")]
    float HP;

    [SerializeField, Header("�o�ꎞ�ړ����x")]
    float Speed;

    [SerializeField, Header("��~�ʒu")]
    Vector2 Position;

    [SerializeField,Header("�J�n�ړ���")]
    bool StartMoveflg;

    /// <summary>
    /// �U���N�[���^�C��
    /// </summary>
    [SerializeField]
    float Attack_Time;


    void Start()
    {
        StartMoveflg = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ꎞ�̈ړ�
        if (StartMoveflg)
        {
            float speed = Speed * Time.deltaTime;
            if (!GameManager.Instance.GetGameOperationFlg)
            {
                speed = 0;
            }

            transform.position = Vector2.MoveTowards(
                transform.position, Position, speed);

            //�ړ��I��
            if ((Vector2)transform.position == Position) 
            {
                StartMoveflg = false;

                //�������ԃJ�E���g�ĊJ
                GameManager.Instance.IsGetTime_flg = true;

            }

        }
        else
        {
            if (GameManager.Instance.GetGameOperationFlg)
            {
                Attack_Time += Time.deltaTime;
            }


        }

    }

    /// <summary>
    /// �_���[�W�v�Z
    /// </summary>
    /// <param name="damage"></param>
    public bool Damage(float damage)
    {
        HP -= damage;

        if (HP <= 0)
        {

            return true;

        }

        return false;
    }

}
