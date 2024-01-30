using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{

    [SerializeField,Header("HP")]
    float HP;

    [SerializeField, Header("登場時移動速度")]
    float Speed;

    [SerializeField, Header("停止位置")]
    Vector2 Position;

    [SerializeField,Header("開始移動中")]
    bool StartMoveflg;

    void Start()
    {
        StartMoveflg=true;
    }

    // Update is called once per frame
    void Update()
    {
        //登場時の移動
        if (StartMoveflg)
        {
            transform.position = Vector2.MoveTowards(
                transform.position, Position, Speed * Time.deltaTime);

            //移動終了
            if ((Vector2)transform.position == Position) 
            {
                StartMoveflg = false;

                //制限時間カウント再開
                GameManager.Instance.IsGetTime_flg = true;

            }

        }
    }
}
