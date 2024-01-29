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

        ////�摜�̎w��
        //image = GetComponent<Image>();
        //if (image != null)
        //{
        //    switch (EnemyType)
        //    {
        //        case Enemy_Type.Type1:
        //            image.sprite = Enemy1;
        //            break;
        //        case Enemy_Type.Type2:
        //            image.sprite = Enemy2;
        //            break;
        //        case Enemy_Type.Type3:
        //            image.sprite = Enemy3;
        //            break;
        //    }
        //}

    }

    private void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

        // �ړ�
        transform.position = Vector2.MoveTowards(
            transform.position, MovePosition, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        MovePosition = transform.position;
        Debug.Log("atatta");
    }

    void SetStart(Vector2 pos, Enemy_Type Type, float EnemyPower)
    {
        pos = StartPosition;
        Type = EnemyType;
        EnemyPower = Power;
    }
}
