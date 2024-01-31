using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeControlScript : MonoBehaviour
{
    /// <summary>
    /// 入力先
    /// </summary>
    [Header("入力先テキストボックス")]
    public Text TextFlame;

    /// <summary>
    /// 分数
    /// </summary>
    private float Minutes;

    /// <summary>
    /// 秒数
    /// </summary>
    private float Seconds;

    // Start is called before the first frame update
    void Start()
    {
        //分数・秒数割り出し
        Seconds = GameManager2.Instance.GetTime_limit % 60;
        Minutes = GameManager2.Instance.GetTime_limit / 60;
    }

    // Update is called once per frame
    void Update()
    {
        //分数・秒数割り出し
        Seconds = (int)GameManager2.Instance.GetTime_limit % 60;
        Minutes = (int)GameManager2.Instance.GetTime_limit / 60;

        //文字入力
        TextFlame.text = Minutes.ToString("00") + ":" + Seconds.ToString("00");
    }

}
