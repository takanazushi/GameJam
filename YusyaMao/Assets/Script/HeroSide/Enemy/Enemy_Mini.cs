using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Mini : MonoBehaviour
{
    [Header("HP")]
    public float HP;

    [Header("ˆÚ“®‘¬“x")]
    public float Speed;

    [Header("ˆÊ’u")]
    public Vector2 Position;

    /// <summary>
    /// ¶¬”Ô†
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
        Type4,
    }
    [Header("“G‚Ìí—Ş")]
    public Enemy_Type EnemyType;

    [Header("“G‚Ì‹­‚³")]
    public float Power;

    [Header("“G‚Ì‰æ‘œ")]
    public Sprite Enemy1;
    public Sprite Enemy2;
    public Sprite Enemy3;
    public Sprite Enemy4;

    //ˆÚ“®‘OˆÊ’u
    private Vector2 StartPosition;
    //ˆÚ“®ŒãˆÊ’u
    private Vector2 MovePosition;

    private void Start()
    {
        StartPosition = new Vector2(-11, Random.Range(0.0f, -3.7f));
        MovePosition = new Vector2(Random.Range(0.0f, -6f), StartPosition.y);

        transform.position = StartPosition;
    }

    private void Update()
    {
        float speed = Speed * Time.deltaTime;
        if (!GameManager.Instance.GetGameOperationFlg)
        {
            speed = 0;
        }

        // ˆÚ“®
        transform.position = Vector2.MoveTowards(
            transform.position, MovePosition, speed);
    }

    /// <summary>
    /// ƒ_ƒ[ƒWŒvZ
    /// </summary>
    /// <param name="damage"></param>
    /// <returns>“|‚µ‚½‚©</returns>
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

    /// <summary>
    /// “G‚ğ¶¬
    /// </summary>
    /// <param name="no">¶¬”Ô†</param>
    /// <param name="hp">HP</param>
    /// <param name="type">‰æ‘œí—Ş</param>
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
