using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// インスタンス
    /// </summary>
    public static GameManager Instance;

    /// <summary>
    /// ゲーム操作可能フラグtrue:可能
    /// </summary>
    bool GameOperationFlg=true;
    /// <summary>
    /// ゲーム操作可能フラグ取得
    /// </summary>
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
    [SerializeField]
    bool IsTime_flg;

    /// <summary>
    /// 制限時間を計測するか取得
    /// </summary>
    public bool IsGetTime_flg
    {
        get { return IsTime_flg; }
        set { IsTime_flg = value;}
    }

    /// <summary>
    /// 残り制限時間取得
    /// </summary>
    public float GetTime_limit
    {
        get { return Time_limit;}
    }    

    /// <summary>
    /// 経過時間取得
    /// </summary>
    public float Get_ElapsedTime
    {
        get { return Time_limit_Start- Time_limit; }
    }

    /// <summary>
    /// リザルト表示
    /// </summary>
    bool Resultflg;

    /// <summary>
    /// リザルトフラグ表示
    /// </summary>
    public bool IsResultflg
    {
        get { return Resultflg; }
        set { Resultflg = value; }
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
        Resultflg = false;
    }

    private void FixedUpdate()
    {
        if (IsTime_flg)
        {
            //経過時間を増加
            Time_limit -= Time.deltaTime;

            if (Time_limit <= 0.0f)
            {
                Time_limit = 0.0f;

                IsTime_flg = false;

            }

        }

    }

    public void On_Result()
    {
        Resultflg = true;
    }

}
