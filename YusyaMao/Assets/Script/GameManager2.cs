using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static GameManager2 Instance;

    /// <summary>
    /// ゲーム操作可能フラグtrue:可能
    /// </summary>
    bool GameOperationFlg;
    public bool GetGameOperationFlg
    {
        get { return GameOperationFlg; }
        set { GameOperationFlg = value; }
    }

    /// <summary>
    /// 開始秒数
    /// </summary>
    [SerializeField]
    float Time_limit_Start;

    /// <summary>
    /// 制限時間、残り秒数
    /// </summary>
    float Time_limit;

    /// <summary>
    /// 制限時間を計測するかtrue:計測する
    /// </summary>
    [SerializeField,Header("制限時間計測flag")]
    bool IsTime_Count;

    /// <summary>
    /// 残り制限時間取得
    /// </summary>
    public float GetTime_limit
    {
        get { return Time_limit; }
    }

    /// <summary>
    /// 経過時間取得
    /// </summary>
    public float Get_ElapsedTime
    {
        get { return Time_limit_Start - Time_limit; }
    }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Time_limit = Time_limit_Start;
    }

    private void FixedUpdate()
    {
        if (IsTime_Count)
        {
            //経過時間を増加
            Time_limit -= Time.deltaTime;

            if (Time_limit <= 0.0f)
            {
                Time_limit = 0.0f;
                IsTime_Count = false;

            }

        }

    }


}