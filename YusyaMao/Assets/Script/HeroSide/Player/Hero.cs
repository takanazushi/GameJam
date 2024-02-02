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

    /// <summary>
    /// HP�e�L�X�g
    /// </summary>
    [SerializeField]
    TextMeshProUGUI textmeshPro;

    Animator animator;

    [SerializeField]
    GameObject effect_Parent;

    /// <summary>
    /// �G�t�F�N�g�v�[��
    /// </summary>
    GameObject[] Effectpool;

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


        int effect_pool_conut = effect_Parent.transform.childCount;
        Effectpool = new GameObject[effect_pool_conut];

        for (int i = 0; i < effect_pool_conut; i++)
        {
            //�X�N���v�g���擾
            Effectpool[i] = effect_Parent.transform.GetChild(i).gameObject;
        }

        textmeshPro.text = Hp.ToString() + ":HP";

        animator=GetComponent<Animator>();
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


                    foreach (var effect in Effectpool)
                    {
                        if (!effect.activeSelf)
                        {
                            effect.transform.position = hit.transform.position;
                            effect.SetActive(true);
                            break;
                        }
                    }

                    //���탂�[�V�����J�n
                    foreach (var weapon in weapon_pool)
                    {
                        weapon.MoveStart(hit.transform.position);
                    }

                }
            }
        }
    }

    public void PowerUpdate(float addpower)
    {
        AttackPower += addpower;
        Debug.Log(AttackPower);
    }

    public void Damage(float damgae)
    {
        Hp -= damgae;
        animator.SetBool("Is_Damage", true);
        if (Hp <= 0)
        {
            Hp = 0;
        }

        textmeshPro.text = Hp.ToString() + ":HP";
    }

    void AnimeDamageEnd()
    {
        animator.SetBool("Is_Damage", false);

    }
}
