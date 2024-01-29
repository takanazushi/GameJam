using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵スクリプトに変更
    GameObject[] Enemy_pool;

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
    /// 実行回数
    /// </summary>
    [SerializeField]
    int exe_num;

    private void Start()
    {
        int enemypool_conut=transform.childCount;
        Enemy_pool = new GameObject[enemypool_conut];

        for (int i = 0; i < enemypool_conut; i++)
        {
            //敵スクリプトを取得
            Enemy_pool[i] = transform.GetChild(i).gameObject;
        }
        exeTime = GameManager.Instance.GetTime_limit- ExeCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        //時間計測
        if(GameManager.Instance.GetTime_limit < exeTime)
        {
            //実行時間再設定
            exeTime = GameManager.Instance.GetTime_limit - ExeCoolTime;

            //回数分実行
            for (int i = 0; i < exe_num;i++)
            {
                foreach (var enemy in Enemy_pool)
                {
                    if (!enemy.activeSelf)
                    {
                        //敵スクリプトの初期化処理を実行
                        enemy.SetActive(true);
                        break;
                    }
                }
            }

        }

        //試験用敵全滅
        if(Input.GetKey(KeyCode.Space)) 
        {
            foreach (var enemy in Enemy_pool)
            {
                enemy.SetActive(false);
            }
        }
    }
}
