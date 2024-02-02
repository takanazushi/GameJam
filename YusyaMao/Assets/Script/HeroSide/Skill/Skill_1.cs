using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skill_1 : MonoBehaviour
{
    [Header("魔法陣オブジェクト")]
    public GameObject MagicCircleObject;
    [Header("ラインオブジェクト")]
    public GameObject MagicLineObject;

    [Header("ライン表示スピード")]
    public float LineSpeed;

    public CoolTime CoolTime;

    /// <summary>
    /// スキル解放フラグtrue:解放済み
    /// </summary>
    [Header("スキル解放")]
    public bool ReleaseFlg;

    /// <summary>
    /// 使用していない時の経過時間
    /// </summary>
    float countTime;

    private void Start()
    {
        MagicLineObject.gameObject.SetActive(false);
        countTime = 0f;
        SkillOpen();
    }


    public void Exe()
    {
        if (!GameManager.Instance.GetGameOperationFlg||CoolTime.CoolTimeFlg || !ReleaseFlg)
        {
            return;
        }

        //クールダウンスタート
        CoolTime.StartCooldown();

        //魔法陣表示
        //ロック解除されたら一つ目の魔法陣表示
        MagicCircleObject.gameObject.SetActive(true);

        //ライン表示
        MagicLineObject.gameObject.SetActive(true);

        if (countTime >= LineSpeed)
        {
            if (!MagicLineObject.gameObject.activeSelf)
            {
                //Line表示
                MagicLineObject.gameObject.SetActive(true);
            }
            else
            {
                countTime = 0;
            }

        }

        countTime += Time.deltaTime;


        Debug.Log("スキル1");
    }


    public void SkillOpen()
    {
        ReleaseFlg=true;
    }

}
