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

    [SerializeField, Header("登場時移動速度")]
    float Speed;

    [SerializeField, Header("停止位置")]
    Vector2 Position;

    [SerializeField,Header("開始移動中")]
    bool StartMoveflg;

    /// <summary>
    /// playerスクリプト
    /// </summary>
    [SerializeField]
    Hero playerData;

    [SerializeField]
    float AttackDamage;

    /// <summary>
    /// 攻撃クールタイム秒
    /// </summary>
    [SerializeField]
    float Attack_Time;

    float Attack_TimeCount;

    [SerializeField]
    GameObject effect_Parent;

    /// <summary>
    /// エフェクトプール
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
            //スクリプトを取得
            Effectpool[i] = effect_Parent.transform.GetChild(i).gameObject;
        }


    }

    // Update is called once per frame
    void Update()
    {
        //登場時の移動
        if (StartMoveflg)
        {
            float speed = Speed * Time.deltaTime;
            if (!GameManager.Instance.GetGameOperationFlg)
            {
                speed = 0;
            }

            transform.position = Vector2.MoveTowards(
                transform.position, Position, speed);

            //移動終了
            if ((Vector2)transform.position == Position) 
            {
                StartMoveflg = false;

                //制限時間カウント再開
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
    /// アニメーション再開
    /// </summary>
    public void AnimaStart()
    {
        if(!gameObject.activeSelf) { return; }

        anim.SetFloat("MoveSpeed", 1.0f);
    }
    /// <summary>
    /// アニメーション停止
    /// </summary>
    public void AnimaStop()
    {
        if (!gameObject.activeSelf) { return; }
        anim.SetFloat("MoveSpeed", 0.0f);
    }

    /// <summary>
    /// 攻撃アニメーション終了時
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
    /// 被ダメアニメーション終了時
    /// </summary>
    public void ReceiveDamageEnd()
    {

        anim.SetBool("Is_ReceiveDamage", false);

    }
    /// <summary>
    /// ダウンアニメーション終了時
    /// </summary>
    public void DownEnd()
    {
        //リザルト表示
        GameManager.Instance.On_Result();
    }

    /// <summary>
    /// ダメージ計算
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
