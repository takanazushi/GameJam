using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Enemy_Mini;

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
    /// �{�X�I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    EnemyBoss Enemy_Boss;

    /// <summary>
    /// �{�X�o������
    /// </summary>
    [SerializeField]
    float EnemyBoss_Time;

    /// <summary>
    /// �{�X�o����������
    /// </summary>
    bool EnemyBossflg;

    /// <summary>
    /// �G�𐶐�������
    /// </summary>
    int Enemy_Count;

    /// <summary>
    /// �G��|������
    /// </summary>
    int KnockOutCount;

    /// <summary>
    /// �G��|�������擾
    /// </summary>
    public int GetKnockOutCount
    {
        get { return KnockOutCount; }
    }

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
        EnemyBossflg = false;
        KnockOutCount = 0;
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

        //�{�X�o�����Ԕ���
        if (!EnemyBossflg&&GameManager.Instance.GetTime_limit < EnemyBoss_Time)
        {
            EnemyBoss_Generator();
        }

    }

    public void Enemy_ColStop()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.AttackStop();

            }
        }
    }

    public void Enemy_ColStart()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.gameObject.activeSelf)
            {
                enemy.AttackReStart();

            }

        }
    }

    /// <summary>
    /// �{�X����
    /// </summary>
    void EnemyBoss_Generator()
    {
        Enemy_Boss.gameObject.SetActive(true);

        //�������ԃJ�E���g��~
        GameManager.Instance.IsGetTime_flg = false;

        EnemyBossflg = true;
    }

    /// <summary>
    /// �G����
    /// </summary>
    void Enemy_Generator()
    {
        foreach (var enemy in Enemy_pool)
        {
            if (!enemy.gameObject.activeSelf)
            {
                //�G�X�N���v�g�̏��������������s
                enemy.gameObject.SetActive(true);

                //���Ԃɂ���ă^�C�v��ύX
                Enemy_Type enemy_Type = Enemy_Type.Type1;

                if (GameManager.Instance.GetTime_limit <= 45)
                {
                    enemy_Type = Enemy_Type.Type4;

                }
                else if (GameManager.Instance.GetTime_limit <= 90)
                {
                    enemy_Type = Enemy_Type.Type3;
                }
                else if (GameManager.Instance.GetTime_limit <= 135)
                {
                    enemy_Type = Enemy_Type.Type2;
                }


                enemy.SetStart(Enemy_Count, Enemy_HP, enemy_Type);

                //todo�G��HP���X�V
                Enemy_HP = Enemy_HP * 2;
                Enemy_Count++;
                break;
            


            }
        }

    }

    /// <summary>
    /// �G�Ƀ_���[�W
    /// </summary>
    /// <param name="tra">Transform�Ŏw��</param>
    /// <param name="damage">�_���[�W</param>
    public void EnemyDamage(Transform tra, float damage)
    {
        foreach (var enemy in Enemy_pool)
        {
            if (enemy.transform == tra) 
            {
                //�U��
                if (enemy.Damage(damage))
                {
                    //�G��|�����ꍇ
                    KnockOutCount++;

                    //player�̍U���͂��X�V
                    playerData.PowerUpdate(playerData.GetAttackPower * 0.5f);
                }
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
        //�{�X�ɍU�����邩
        else if (Enemy_Boss.gameObject.activeSelf)
        {
            Enemy_Boss.Damage(damage);
        }

    }

    /// <summary>
    /// �ʒu����߂��G��Transform��Ԃ�
    /// </summary>
    /// <param name="pos">�ʒu</param>
    /// <returns></returns>
    public Vector3 EnemyPointSearch(Vector3 pos)
    {
        Transform listSearch = null;


        foreach (var enemy in Enemy_pool)
        {

            if (!enemy.gameObject.activeSelf)
            {
                continue;
            }

            //�N���b�N�����ʒu�ƃI�u�W�F�N�g�Ƃ̋������v�Z
            float distance = Vector3.Distance(pos, enemy.gameObject.transform.position);

            listSearch = enemy.gameObject.transform;
        }


        //�{�X����
        if (listSearch==null)
        {
            if (Enemy_Boss.gameObject.activeSelf)
            {
                listSearch = Enemy_Boss.gameObject.transform;
            }
        }

        if(listSearch == null)
        {
            return pos;

        }
        else
        {
            return listSearch.position;

        }
    }
}
