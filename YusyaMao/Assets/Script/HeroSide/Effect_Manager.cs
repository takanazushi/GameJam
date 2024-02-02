using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{

    /// <summary>
    /// エフェクトの親
    /// </summary>
    [SerializeField]
    private GameObject[] Effect_poolParent;

    /// <summary>
    /// エフェクトプール
    /// </summary>
    [SerializeField]
    private GameObject[] Effect_pool;


    private void Awake()
    {
        int effectpool_conut = transform.childCount;
        Effect_pool = new GameObject[effectpool_conut];

        for (int i = 0; i < effectpool_conut; i++)
        {
            //敵スクリプトを取得
            Effect_pool[i] = transform.GetChild(i).gameObject;
        }
    }

    public void EffectStart()
    {
        foreach (GameObject effect in Effect_pool)
        {
            if (!effect.activeSelf)
            {
                effect.SetActive(true);
            }
        }
    }
}
