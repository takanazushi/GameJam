using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //�G�X�N���v�g�ɕύX
    Enemy_Mini[] Enemy_pool;

    /// <summary>
    /// �N�[���^�C��
    /// </summary>
    [SerializeField]
    float ExeCoolTime;

    /// <summary>
    /// ���s���ԕۑ�
    /// </summary>
    float exeTime;

    /// <summary>
    /// ���s��
    /// </summary>
    [SerializeField]
    int exe_num;

    private void Start()
    {
        int enemypool_conut=transform.childCount;
        Enemy_pool = new Enemy_Mini[enemypool_conut];

        for (int i = 0; i < enemypool_conut; i++)
        {
            //�G�X�N���v�g���擾
            Enemy_pool[i] = transform.GetChild(i).GetComponent<Enemy_Mini>();
        }
        exeTime = GameManager.Instance.GetTime_limit- ExeCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԍv��
        if(GameManager.Instance.GetTime_limit < exeTime)
        {
            //���s���ԍĐݒ�
            exeTime = GameManager.Instance.GetTime_limit - ExeCoolTime;

            //�񐔕����s
            for (int i = 0; i < exe_num;i++)
            {
                foreach (var enemy in Enemy_pool)
                {
                    if (!enemy.gameObject.activeSelf)
                    {
                        //�G�X�N���v�g�̏��������������s
                        enemy.gameObject.SetActive(true);
                        enemy.SetStart();
                        break;
                    }
                }
            }

        }

        //�����p�G�S��
        if(Input.GetKey(KeyCode.Space)) 
        {
            foreach (var enemy in Enemy_pool)
            {
                enemy.gameObject.SetActive(false);
            }
        }
    }
}
