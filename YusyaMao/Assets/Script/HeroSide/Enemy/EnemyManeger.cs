using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Enemy_Mini;

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
    /// ボスオブジェクト
    /// </summary>
    [SerializeField]
    EnemyBoss Enemy_Boss;

    /// <summary>
    /// ボス出現時間
    /// </summary>
    [SerializeField]
    float EnemyBoss_Time;

    /// <summary>
    /// ボス出現させたか
    /// </summary>
    bool EnemyBossflg;

    /// <summary>
    /// 敵を生成した数
    /// </summary>
    int Enemy_Count;

    /// <summary>
    /// 敵を倒した数
    /// </summary>
    int KnockOutCount;

    /// <summary>
    /// 敵を倒した数取得
    /// </summary>
    public int GetKnockOutCount
    {
        get { return KnockOutCount; }
    }

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
        EnemyBossflg = false;
        KnockOutCount = 0;
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

        //ボス出現時間判定
        if (!EnemyBossflg&&GameManager.Instance.GetTime_limit < EnemyBoss_Time)
        {
            EnemyBoss_Generator();
        }

    }

    public void Enemy_ColStop()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.AttackStop();

            }
        }
    }

    public void Enemy_ColStart()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.AttackReStart();

            }

        }
    }

    /// <summary>
    /// ボス生成
    /// </summary>
    void EnemyBoss_Generator()
    {
        Enemy_Boss.gameObject.SetActive(true);

        //制限時間カウント停止
        GameManager.Instance.IsGetTime_flg = false;

        EnemyBossflg = true;
    }

    /// <summary>
    /// 敵生成
    /// </summary>
    void Enemy_Generator()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (!enemy.gameObject.activeSelf)
            {
                //敵スクリプトの初期化処理を実行
                enemy.gameObject.SetActive(true);

                //時間によってタイプを変更
                Enemy_Type enemy_Type = Enemy_Type.Type1;

                if (GameManager.Instance.GetTime_limit <= 45)
                {
                    enemy_Type = Enemy_Type.Type4;

                }
                else if (GameManager.Instance.GetTime_limit <= 90)
                {
                    enemy_Type = Enemy_Type.Type3;
                }
                else if (GameManager.Instance.GetTime_limit <= 135)
                {
                    enemy_Type = Enemy_Type.Type2;
                }


                enemy.SetStart(Enemy_Count, Enemy_HP, enemy_Type);

                //todo敵のHPを更新
                Enemy_HP = Enemy_HP * 2;
                Enemy_Count++;
                break;
            


            }
        }

    }

    /// <summary>
    /// 敵にダメージ
    /// </summary>
    /// <param name="tra">Transformで指定</param>
    /// <param name="damage">ダメージ</param>
    public void EnemyDamage(Transform tra, float damage)
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.transform == tra) 
            {
                //攻撃
                if (enemy.Damage(damage))
                {
                    //敵を倒した場合
                    KnockOutCount++;

                    //playerの攻撃力を更新
                    playerData.PowerUpdate(playerData.GetAttackPower * 0.5f);
                }
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
        //ボスに攻撃するか
        else if (Enemy_Boss.gameObject.activeSelf)
        {
            Enemy_Boss.Damage(damage);
        }

    }

    /// <summary>
    /// 位置から近い敵のTransformを返す
    /// </summary>
    /// <param name="pos">位置</param>
    /// <returns></returns>
    public Vector3 EnemyPointSearch(Vector3 pos)
    {
        Transform listSearch = null;


        foreach (var enemy in Enemy_pool)
        {

            if (!enemy.gameObject.activeSelf)
            {
                continue;
            }

            //クリックした位置とオブジェクトとの距離を計算
            float distance = Vector3.Distance(pos, enemy.gameObject.transform.position);

            listSearch = enemy.gameObject.transform;
        }


        //ボス判定
        if (listSearch==null)
        {
            if (Enemy_Boss.gameObject.activeSelf)
            {
                listSearch = Enemy_Boss.gameObject.transform;
            }
        }

        if(listSearch == null)
        {
            return pos;

        }
        else
        {
            return listSearch.position;

        }
    }
}
