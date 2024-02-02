using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_1Manager : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    /// <summary>
    /// ����v�[��
    /// </summary>
    GameObject[] Magic_pool;

    /// <summary>
    /// �G�X�V�G������
    /// ���̐����Ƃɖ��@�w�������܂�
    /// </summary>
    [SerializeField]
    int Circle_Up_count;

    //Line�̋����l
    [SerializeField]
    public int LineAttackPower;

    public Skill_1MagicLine MagicLine;

    

    private void Awake()
    {
        int magicpool_conut = transform.childCount;
        Magic_pool = new GameObject[magicpool_conut];

        for (int i = 0; i < magicpool_conut; i++)
        {
            //�Q�[���I�u�W�F�N�g���擾
            Magic_pool[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        //�G�������m�F
        if (EnemyManeger.GetKnockOutCount >= Circle_Up_count)
        {
            Circle_Up_count += Circle_Up_count;

            foreach (var magic in Magic_pool)
            {
                if (!magic.activeSelf)
                {
                    ////Line�̋����A�T�C�Y�ύX
                    //MagicLine.AttackPower *= LineAttackPower;
                    //MagicLine.gameObject.transform.localScale += new Vector3(2f, 0f, 0f);
                    ////���@�w�̕\��
                    //magic.SetActive(true);
                    //break;
                }
            }

        }
    }
}
