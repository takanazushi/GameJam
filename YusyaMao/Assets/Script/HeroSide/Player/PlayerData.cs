using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    [SerializeField]
    GameObject weapon_Parent;

    /// <summary>
    /// ���탊�X�g
    /// </summary>
    Weapon_Move[] weapon_pool;

    /// <summary>
    /// �U����
    /// </summary>
    [SerializeField]
    float AttackPower;

    public float GetAttackPower
    {
        get { return AttackPower; }
    }

    private void Start()
    {
        int weapon_pool_conut = weapon_Parent.transform.childCount;
        weapon_pool = new Weapon_Move[weapon_pool_conut];

        for (int i = 0; i < weapon_pool_conut; i++)
        {
            //�G�X�N���v�g���擾
            weapon_pool[i] = weapon_Parent.transform.GetChild(i).GetComponent<Weapon_Move>();

        }


    }

    // Update is called once per frame
    void Update()
    {
        //�G�ɍU�����s
        if (GameManager.Instance.GetGameOperationFlg &&
            GameManager.Instance.IsGetTime_flg &&
            Input.GetMouseButtonDown(0))
        {
            EnemyManeger.EnemyDamage(AttackPower);

            //���탂�[�V�����J�n
            foreach (var weapon in weapon_pool)
            {
                weapon.MoveStart();
            }
        }
    }

    public void PowerUpdate(float addpower)
    {
        AttackPower += addpower;
        Debug.Log("uppo:" + AttackPower);
    }
}
