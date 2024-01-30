using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        StartMoveflg=true;
    }

    // Update is called once per frame
    void Update()
    {
        //�o�ꎞ�̈ړ�
        if (StartMoveflg)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, Position, Speed * Time.deltaTime);

            //�ړ��I��
            if ((Vector2)transform.position == Position) 
            {
                StartMoveflg = false;

                //�������ԃJ�E���g�ĊJ
                GameManager.Instance.IsGetTime_flg = true;

            }

        }
    }
}
