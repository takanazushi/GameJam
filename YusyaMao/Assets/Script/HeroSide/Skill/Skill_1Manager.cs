using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1Manager : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    /// <summary>
    /// 武器プール
    /// </summary>
    GameObject[] Magic_pool;

    /// <summary>
    /// 敵更新敵討伐数
    /// この数ごとに魔法陣が増えます
    /// </summary>
    [SerializeField]
    int Circle_Up_count;

    //Lineの強化値
    [SerializeField]
    public int LineAttackPower;

    public Skill_1MagicLine MagicLine;

    

    private void Awake()
    {
        int magicpool_conut = transform.childCount;
        Magic_pool = new GameObject[magicpool_conut];

        for (int i = 0; i < magicpool_conut; i++)
        {
            //ゲームオブジェクトを取得
            Magic_pool[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        //敵討伐数確認
        if (EnemyManeger.GetKnockOutCount >= Circle_Up_count)
        {
            Circle_Up_count += Circle_Up_count;

            foreach (var magic in Magic_pool)
            {
                if (!magic.activeSelf)
                {
                    ////Lineの強化、サイズ変更
                    //MagicLine.AttackPower *= LineAttackPower;
                    //MagicLine.gameObject.transform.localScale += new Vector3(2f, 0f, 0f);
                    ////魔法陣の表示
                    //magic.SetActive(true);
                    //break;
                }
            }

        }
    }
}
