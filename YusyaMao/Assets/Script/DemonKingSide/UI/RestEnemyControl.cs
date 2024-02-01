using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestEnemyControl : MonoBehaviour
{
    /// <summary>
    /// text指定用
    /// </summary>
    [Header("入力先テキストボックス")]
    public Text Textflame;

    /// <summary>
    /// 残り人数
    /// </summary>
    [Header("残り人数")]
    public int Rest;

    /// <summary>
    /// KOフラグ
    /// </summary>
    private bool KO;

    // Update is called once per frame
    void Update()
    {
        //KO時処理
        if(KO)
        {
            Rest -= 1;
            KO = false;
        }

        //残り人数表示　フォントがひらがなのみ対応のためひらがなで表示
        Textflame.text = ("のこり" + Rest.ToString() + "にん");
    }

    /// <summary>
    /// 敵撃破時実行用publicメゾット
    /// </summary>
    public void BraverKO()
    {
        KO = true;
    }

}
