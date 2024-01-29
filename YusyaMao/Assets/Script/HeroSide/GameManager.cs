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
    bool GameOperationFlg;
    public bool GetGameOperationFlg
    {
        get { return GameOperationFlg; }
        set { GameOperationFlg = value; }
    }

    /// <summary>
    /// 制限時間、秒
    /// </summary>
    [SerializeField]
    float Time_limit;

    /// <summary>
    /// 制限時間を計測するかtrue:計測する
    /// </summary>
    [SerializeField]
    bool IsTime_Count;

    public float GetTime_limit
    {
        get { return Time_limit;}
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
