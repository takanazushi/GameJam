using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Manager : MonoBehaviour
{

    /// <summary>
    /// �G�t�F�N�g�̐e
    /// </summary>
    [SerializeField]
    private GameObject[] Effect_poolParent;

    /// <summary>
    /// �G�t�F�N�g�v�[��
    /// </summary>
    [SerializeField]
    private GameObject[] Effect_pool;


    private void Awake()
    {
        int effectpool_conut = transform.childCount;
        Effect_pool = new GameObject[effectpool_conut];

        for (int i = 0; i < effectpool_conut; i++)
        {
            //�G�X�N���v�g���擾
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
