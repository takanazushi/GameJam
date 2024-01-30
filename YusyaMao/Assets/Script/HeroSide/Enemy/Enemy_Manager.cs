using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    [Header("ボス出現")]
    public bool CreateBoss;

    [Header("雑魚のプレハブ")]
    public GameObject EnemyMini;

    [Header("リスポーンする敵の数")]
    public int Menber;

    [Header("リスポーン間隔")]
    public int RespawnTime;

    private float CountTime;


    //子オブジェクトのリスト
    private List<GameObject> EnemyMiniList = new List<GameObject>();

    private void Update()
    {
        //生成数が0なら敵を生成
        if (EnemyMiniList.Count < Menber && CountTime <= 0) 
        {
            //敵を生成
            SpawnEnemyMini();
            
            //リスポーンタイムをリセット（ランダムにしてもいいかな）
            CountTime = RespawnTime;
        }
        else
        {
            CountTime -= Time.deltaTime;
        }
        //敵をリストから削除
        RemoveEnemyMini();
    }

    // 敵の生成
    private void SpawnEnemyMini()
    {
        //プレハブから敵を生成
        GameObject newEnemy = Instantiate(EnemyMini, transform.position, Quaternion.identity);
        EnemyMiniList.Add(newEnemy);
    }

    //倒された（HPが0になった）敵をリストから削除
    private void RemoveEnemyMini()
    {
        EnemyMiniList.RemoveAll(enemy => enemy.GetComponent<Enemy_Mini>().HP <= 0);
    }
}
