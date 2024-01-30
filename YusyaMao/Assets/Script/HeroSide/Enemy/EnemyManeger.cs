using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManeger : MonoBehaviour
{
    [SerializeField]
    PlayerData playerData;

    /// <summary>
    /// �G��HP�����l
    /// </summary>
    [SerializeField]
    float Enemy_HP;

    /// <summary>
    /// �G�I�u�W�F�N�g
    /// </summary>
    Enemy_Mini[] Enemy_pool;

    /// <summary>
    /// �G�𐶐�������
    /// </summary>
    int Enemy_Count;

    /// <summary>
    /// �G��|������
    /// </summary>
    int KnockOutCount;

    /// <summary>
    /// �G�𐶐����邩true:��������
    /// </summary>
    [SerializeField]
    bool Enemy_Generatorflg;

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
    /// ��x�̎��s��
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


    void Update()
    {
        //�G����
        if (Enemy_Generatorflg)
        {
            //���Ԍv��
            if(GameManager.Instance.GetTime_limit < exeTime)
            {
                //���s���ԍĐݒ�
                exeTime = GameManager.Instance.GetTime_limit - ExeCoolTime;

                //�񐔕����s
                for (int i = 0; i < exe_num;i++)
                {
                    Enemy_Generator();
                }
            }
        }
    }

    void Enemy_Generator()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (!enemy.gameObject.activeSelf)
            {
                //�G�X�N���v�g�̏��������������s
                enemy.gameObject.SetActive(true);
                enemy.SetStart(Enemy_Count, Enemy_HP);

                //todo�G�̋������X�V
                Enemy_HP = Enemy_HP * 2;
                Enemy_Count++;
                break;
            }
        }

    }

    /// <summary>
    /// �G�Ƀ_���[�W���s
    /// </summary>
    /// <param name="damage">�^����_���[�W</param>
    public void EnemyDamage(float damage)
    {
        Enemy_Mini hitenemy=null;
        int enemyno =1000;
        //�ԍ�������������擾
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                if(enemyno>= enemy.GetEnemy_No)
                {
                    enemyno = enemy.GetEnemy_No;
                    hitenemy = enemy;
                }
            }
        }

        if (hitenemy)
        {

            //�U��
            if (hitenemy.Damage(damage))
            {
                //�G��|�����ꍇ
                KnockOutCount++;

                //player�̍U���͂��X�V
                playerData.PowerUpdate(playerData.GetAttackPower*0.5f);
            }

        }

    }
}
