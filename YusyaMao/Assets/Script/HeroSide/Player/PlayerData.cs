using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    [SerializeField]
    GameObject weapon_Parent;

    /// <summary>
    /// 武器リスト
    /// </summary>
    Weapon_Move[] weapon_pool;

    /// <summary>
    /// 攻撃力
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
            //敵スクリプトを取得
            weapon_pool[i] = weapon_Parent.transform.GetChild(i).GetComponent<Weapon_Move>();

        }


    }

    // Update is called once per frame
    void Update()
    {
        //敵に攻撃実行
        if (GameManager.Instance.GetGameOperationFlg &&
            GameManager.Instance.IsGetTime_flg &&
            Input.GetMouseButtonDown(0))
        {
            EnemyManeger.EnemyDamage(AttackPower);

            //武器モーション開始
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
