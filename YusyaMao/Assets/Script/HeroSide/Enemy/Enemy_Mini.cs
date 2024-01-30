using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Mini : MonoBehaviour
{
    [Header("HP")]
    public float HP;

    [Header("�ړ����x")]
    public float Speed;

    [Header("�ʒu")]
    public Vector2 Position;

    /// <summary>
    /// �����ԍ�
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
    [Header("�G�̎��")]
    public Enemy_Type EnemyType;

    [Header("�G�̋���")]
    public float Power;

    [Header("�G�̉摜")]
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;

    //�ړ��O�ʒu
    private Vector2 StartPosition;
    //�ړ���ʒu
    private Vector2 MovePosition;

    //�摜�ύX
    //private Image image;

    private void Start()
    {
        StartPosition = new Vector2(-11, Random.Range(1.7f, -3.5f));
        MovePosition = new Vector2(Random.Range(-2.5f, -6f), StartPosition.y);

        transform.position = StartPosition;


    }

    private void Update()
    {
        // �ړ�
        transform.position = Vector2.MoveTowards(
            transform.position, MovePosition, Speed * Time.deltaTime);
    }

    /// <summary>
    /// �_���[�W�v�Z
    /// </summary>
    /// <param name="damage"></param>
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
