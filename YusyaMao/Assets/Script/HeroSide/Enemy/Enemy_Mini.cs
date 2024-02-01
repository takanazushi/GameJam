using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Enemy_Mini : MonoBehaviour
{
    [Header("HP")]
    public float HP;

    [Header("移動速度")]
    public float Speed;

    [Header("攻撃速度")]
    public float AttackSpeed;

    [Header("移動速度")]
    public float MoveSpeed;

    [Header("位置")]
    public Vector2 Position;

    /// <summary>
    /// 生成番号
    /// </summary>
    [SerializeField]
    int Enemy_No;

    [SerializeField,Header("敵の攻撃力")]
    public float Power;

    /// <summary>
    /// 攻撃リキャスト
    /// </summary>
    [SerializeField]
    float Attack_ReTime;

    float ReTime;

    /// <summary>
    /// playerスクリプト
    /// </summary>
    [SerializeField]
    PlayerData playerData;

    public int GetEnemy_No
    {
        get { return Enemy_No; }
    }

    /// <summary>
    /// 移動タイプ
    /// </summary>
    public enum Enemy_MoveType
    {
        /// <summary>
        /// 移動なし
        /// </summary>
        Stop,

        /// <summary>
        /// 待機場所まで移動
        /// </summary>
        Move_StopAria,

        /// <summary>
        /// playeに体当たり
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
    [Header("敵の種類")]
    public Enemy_Type EnemyType;


    [Header("敵の画像")]
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;
    public Sprite Enemy4;

    //移動前位置
    private Vector2 StartPosition;
    //移動後位置
    private Vector2 MovePosition;

    private void Update()
    {
        // 移動
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
    /// 移動更新
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

                    //攻撃減少
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

                    //目標に到達したか
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

                    //目標に到達したか
                    float subn = transform.position.x - MovePosition.x;
                    if (Mathf.Abs(subn) <= 0.1f)
                    {
                        SetMoveType(Enemy_MoveType.Move_StopAria, AttackSpeed, false);

                        //攻撃
                        playerData.Damage(Power);
                    }

                    break;
                }
        }
    }


    /// <summary>
    /// ダメージを受ける
    /// </summary>
    /// <param name="damage">ダメージ</param>
    /// <returns>倒したか</returns>
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
    /// 敵開始
    /// </summary>
    /// <param name="no">生成番号</param>
    /// <param name="hp">HP</param>
    /// <param name="type">画像種類</param>
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
