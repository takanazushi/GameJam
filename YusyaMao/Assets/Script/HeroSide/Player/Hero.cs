using TMPro;
using UnityEngine;

public class Hero : MonoBehaviour
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

    /// <summary>
    /// HP
    /// </summary>
    [SerializeField]
    float Hp;

    [SerializeField]
    TextMeshProUGUI textmeshPro;

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

        textmeshPro.text = Hp.ToString() + ":HP";
    }

    // Update is called once per frame
    void Update()
    {
        //�G�ɍU�����s
        if (Input.GetMouseButtonDown(0) &&
            GameManager.Instance.GetGameOperationFlg &&
            GameManager.Instance.IsGetTime_flg)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    EnemyManeger.EnemyDamage(hit.transform, AttackPower);

                    //���탂�[�V�����J�n
                    foreach (var weapon in weapon_pool)
                    {
                        weapon.MoveStart(hit.transform.position);
                    }

                }
            }
        }
    }

    /// <summary>
    /// �U�������s�ł��邩����
    /// </summary>
    /// <returns></returns>
    bool IsAttack()
    {
        bool flg = false;

        if (Input.GetMouseButtonDown(0) &&
            GameManager.Instance.GetGameOperationFlg &&
            GameManager.Instance.IsGetTime_flg)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    flg = true;
                }
            }

        }

        return flg;
    }

    public void PowerUpdate(float addpower)
    {
        AttackPower += addpower;
    }

    public void Damage(float damgae)
    {
        Hp -= damgae;

        if (Hp <= 0)
        {
            Hp = 0;
        }

        textmeshPro.text = Hp.ToString() + ":HP";
    }
}
