using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnemyBoss : MonoBehaviour
{

    Animator anim;

    [SerializeField,Header("HP")]
    float HP;

    [SerializeField, Header("�o�ꎞ�ړ����x")]
    float Speed;

    [SerializeField, Header("��~�ʒu")]
    Vector2 Position;

    [SerializeField,Header("�J�n�ړ���")]
    bool StartMoveflg;

    /// <summary>
    /// player�X�N���v�g
    /// </summary>
    [SerializeField]
    Hero playerData;

    [SerializeField]
    float AttackDamage;

    /// <summary>
    /// �U���N�[���^�C���b
    /// </summary>
    [SerializeField]
    float Attack_Time;

    float Attack_TimeCount;

    [SerializeField]
    GameObject effect_Parent;

    /// <summary>
    /// �G�t�F�N�g�v�[��
    /// </summary>
    GameObject[] Effectpool;


    void Start()
    {
        StartMoveflg = true;
        anim = GetComponent<Animator>();


        int effect_pool_conut = effect_Parent.transform.childCount;
        Effectpool = new GameObject[effect_pool_conut];

        for (int i = 0; i < effect_pool_conut; i++)
        {
            //�X�N���v�g���擾
            Effectpool[i] = effect_Parent.transform.GetChild(i).gameObject;
        }


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
                Attack_TimeCount += Time.deltaTime;
            }

            if (Attack_TimeCount >= Attack_Time)
            {

                anim.SetBool("Attack", true);
                Attack_TimeCount = 0.0f;
            }


        }

    }

    /// <summary>
    /// �A�j���[�V�����ĊJ
    /// </summary>
    public void AnimaStart()
    {
        if(!gameObject.activeSelf) { return; }

        anim.SetFloat("MoveSpeed", 1.0f);
    }
    /// <summary>
    /// �A�j���[�V������~
    /// </summary>
    public void AnimaStop()
    {
        if (!gameObject.activeSelf) { return; }
        anim.SetFloat("MoveSpeed", 0.0f);
    }

    /// <summary>
    /// �U���A�j���[�V�����I����
    /// </summary>
    public void AttackEnd()
    {
        foreach (var effect in Effectpool)
        {
            if (!effect.activeSelf)
            {
                effect.transform.position = playerData.transform.position;
                effect.SetActive(true);
                break;
            }
        }

        playerData.Damage(AttackDamage);
        anim.SetBool("Attack", false);

    }
    /// <summary>
    /// ��_���A�j���[�V�����I����
    /// </summary>
    public void ReceiveDamageEnd()
    {

        anim.SetBool("Is_ReceiveDamage", false);

    }
    /// <summary>
    /// �_�E���A�j���[�V�����I����
    /// </summary>
    public void DownEnd()
    {
        //���U���g�\��
        GameManager.Instance.On_Result();
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
            anim.SetBool("Is_Down", true);
            

            return true;

        }

        if (!anim.GetBool("Is_ReceiveDamage"))
        {
            anim.SetBool("Is_ReceiveDamage", true);
        }

        return false;
    }

}
