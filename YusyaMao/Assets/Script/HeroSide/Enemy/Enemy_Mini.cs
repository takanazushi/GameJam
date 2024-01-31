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

    [Header("位置")]
    public Vector2 Position;

    /// <summary>
    /// 生成番号
    /// </summary>
    [SerializeField]
    int Enemy_No;

    WaitForSeconds wait;

    IEnumerator Attack_col;

    [SerializeField,Header("敵の攻撃力")]
    public float Power;

    /// <summary>
    /// 攻撃リキャスト
    /// </summary>
    [SerializeField]
    float Attack_ReTime;

    /// <summary>
    /// playerスクリプト
    /// </summary>
    [SerializeField]
    PlayerData playerData;

    public int GetEnemy_No
    {
        get { return Enemy_No; }
    }

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

    private void Start()
    {
        StartPosition = new Vector2(-11, Random.Range(0.0f, -3.7f));
        MovePosition = new Vector2(Random.Range(0.0f, -6f), StartPosition.y);

        transform.position = StartPosition;

        wait = new(Attack_ReTime);

        Attack_col = Attackcol();

        StartCoroutine(Attack_col);
    }

    private void Update()
    {
        float speed = Speed * Time.deltaTime;
        if (!GameManager.Instance.GetGameOperationFlg)
        {
            speed = 0;
        }

        // 移動
        transform.position = Vector2.MoveTowards(
            transform.position, MovePosition, speed);
    }

    public void AttackStop()
    {
        StopCoroutine(Attack_col);
    }

    public void AttackReStart()
    {
        StartCoroutine(Attack_col);
    }

    IEnumerator Attackcol()
    {
        yield return wait;
        Debug.Log("敵攻撃");
        playerData.Damage(Power);


        Attack_col = Attackcol();
        StartCoroutine(Attack_col);
    }

    /// <summary>
    /// ダメージ計算
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
    /// 敵を生成
    /// </summary>
    /// <param name="no">生成番号</param>
    /// <param name="hp">HP</param>
    /// <param name="type">画像種類</param>
    public void SetStart(int no,float hp, Enemy_Type type)
    {
        Enemy_No = no;
        HP = hp;
        StartPosition = new Vector2(-11, Random.Range(1.7f, -3.5f));
        MovePosition = new Vector2(Random.Range(-2.5f, -6f), StartPosition.y);
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
