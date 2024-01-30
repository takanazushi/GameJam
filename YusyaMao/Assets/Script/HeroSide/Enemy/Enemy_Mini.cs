using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    public int GetEnemy_No
    {
        get { return Enemy_No; }
    }

    public enum Enemy_Type
    {
        Type1,
        Type2,
        Type3,
    }
    [Header("敵の種類")]
    public Enemy_Type EnemyType;

    [Header("敵の強さ")]
    public float Power;

    [Header("敵の画像")]
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;

    //移動前位置
    private Vector2 StartPosition;
    //移動後位置
    private Vector2 MovePosition;

    //画像変更
    //private Image image;

    private void Start()
    {
        StartPosition = new Vector2(-11, Random.Range(1.7f, -3.5f));
        MovePosition = new Vector2(Random.Range(-2.5f, -6f), StartPosition.y);

        transform.position = StartPosition;


    }

    private void Update()
    {
        // 移動
        transform.position = Vector2.MoveTowards(
            transform.position, MovePosition, Speed * Time.deltaTime);
    }

    /// <summary>
    /// ダメージ計算
    /// </summary>
    /// <param name="damage"></param>
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

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    MovePosition = transform.position;
    //    Debug.Log("atatta");
    //}

    public void SetStart(Vector2 pos, Enemy_Type Type, float EnemyPower)
    {
        pos = StartPosition;
        Type = EnemyType;
        EnemyPower = Power;
    }

    public void SetStart(int no,float hp)
    {
        Enemy_No = no;
        HP = hp;
        StartPosition = new Vector2(-11, Random.Range(1.7f, -3.5f));
        MovePosition = new Vector2(Random.Range(-2.5f, -6f), StartPosition.y);
        transform.position = StartPosition;


        //    pos = StartPosition;
        //    Type = EnemyType;
        //    EnemyPower = Power;
        }
}
