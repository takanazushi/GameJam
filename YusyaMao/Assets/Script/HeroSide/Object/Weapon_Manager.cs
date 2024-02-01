using UnityEngine;

public class Weapon_Manager : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    /// <summary>
    /// 武器プール
    /// </summary>
    GameObject[] Weapon_pool;

    /// <summary>
    /// 武器数更新敵討伐数
    /// この数ごとに武器が増えます
    /// </summary>
    [SerializeField]
    int Weapon_Up_count;

    private void Awake()
    {
        int weaponpool_conut = transform.childCount;
        Weapon_pool = new GameObject[weaponpool_conut];

        for (int i = 0; i < weaponpool_conut; i++)
        {
            //ゲームオブジェクトを取得
            Weapon_pool[i] = transform.GetChild(i).gameObject;
        }
    }

    private void Update()
    {
        //敵討伐数確認
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
