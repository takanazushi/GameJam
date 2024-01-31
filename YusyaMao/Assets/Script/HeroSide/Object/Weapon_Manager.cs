using UnityEngine;

public class Weapon_Manager : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    /// <summary>
    /// ����v�[��
    /// </summary>
    GameObject[] Weapon_pool;

    /// <summary>
    /// ���퐔�X�V�G������
    /// ���̐����Ƃɕ��킪�����܂�
    /// </summary>
    [SerializeField]
    int Weapon_Up_count;

    private void Awake()
    {
        int weaponpool_conut = transform.childCount;
        Weapon_pool = new GameObject[weaponpool_conut];

        for (int i = 0; i < weaponpool_conut; i++)
        {
            //�Q�[���I�u�W�F�N�g���擾
            Weapon_pool[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        //�G�������m�F
        if (EnemyManeger.GetKnockOutCount >= Weapon_Up_count)
        {
            Weapon_Up_count += Weapon_Up_count;

            foreach (var weapon in Weapon_pool)
            {
                if (!weapon.activeSelf)
                {
                    weapon.SetActive(true);
                    break;
                }
            }

        }
    }

}
