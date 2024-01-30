using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    /// <summary>
    /// 敵のHP初期値
    /// </summary>
    [SerializeField]
    float Enemy_HP;

    /// <summary>
    /// 敵オブジェクト
    /// </summary>
    Enemy_Mini[] Enemy_pool;

    /// <summary>
    /// 敵を生成した数
    /// </summary>
    int Enemy_Count;

    /// <summary>
    /// 敵を倒した数
    /// </summary>
    int KnockOutCount;

    /// <summary>
    /// 敵を生成するかtrue:生成あり
    /// </summary>
    [SerializeField]
    bool Enemy_Generatorflg;

    /// <summary>
    /// クールタイム
    /// </summary>
    [SerializeField]
    float ExeCoolTime;

    /// <summary>
    /// 実行時間保存
    /// </summary>
    float exeTime;

    /// <summary>
    /// 一度の実行回数
    /// </summary>
    [SerializeField]
    int exe_num;

    private void Start()
    {
        int enemypool_conut=transform.childCount;
        Enemy_pool = new Enemy_Mini[enemypool_conut];

        for (int i = 0; i < enemypool_conut; i++)
        {
            //敵スクリプトを取得
            Enemy_pool[i] = transform.GetChild(i).GetComponent<Enemy_Mini>();
        }
        exeTime = GameManager.Instance.GetTime_limit- ExeCoolTime;
    }


    void Update()
    {
        //敵生成
        if (Enemy_Generatorflg)
        {
            //時間計測
            if(GameManager.Instance.GetTime_limit < exeTime)
            {
                //実行時間再設定
                exeTime = GameManager.Instance.GetTime_limit - ExeCoolTime;

                //回数分実行
                for (int i = 0; i < exe_num;i++)
                {
                    Enemy_Generator();
                }
            }
        }
    }

    void Enemy_Generator()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (!enemy.gameObject.activeSelf)
            {
                //敵スクリプトの初期化処理を実行
                enemy.gameObject.SetActive(true);
                enemy.SetStart(Enemy_Count, Enemy_HP);

                //todo敵の強さを更新
                Enemy_HP = Enemy_HP * 2;
                Enemy_Count++;
                break;
            }
        }

    }

    /// <summary>
    /// 敵にダメージ実行
    /// </summary>
    /// <param name="damage">与えるダメージ</param>
    public void EnemyDamage(float damage)
    {
        Enemy_Mini hitenemy=null;
        int enemyno =1000;
        //番号が小さいやつを取得
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                if(enemyno>= enemy.GetEnemy_No)
                {
                    enemyno = enemy.GetEnemy_No;
                    hitenemy = enemy;
                }
            }
        }

        if (hitenemy)
        {

            //攻撃
            if (hitenemy.Damage(damage))
            {
                //敵を倒した場合
                KnockOutCount++;

                //playerの攻撃力を更新
                playerData.PowerUpdate(playerData.GetAttackPower*0.5f);
            }

        }

    }
}
