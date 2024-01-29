using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("敵のデータ")]
    private EnemyData enemyData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    private int HP;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyData == null)
        {
            Debug.LogError("敵のデータいれてませんよ(>_<)");
        }
        else
        {
            HP = enemyData.MaxHP;
            Debug.Log(enemyData.name + "HP：" + HP);
        }

        if (playerData == null)
        {
            Debug.LogError("プレイヤーのデータ入れてませんよ(>_<)");
        }
        else
        {
            Debug.Log("プレイヤーの攻撃力：" + playerData.ArrackPower);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //マウスが敵の上にあって、クリックされたときにHPを減らす
        if (Input.GetMouseButtonDown(0) && IsMouseOver())
        {
            HP -= playerData.ArrackPower;
            Debug.Log(enemyData.name + "HP：" + HP);
        }

        if (HP <= 0)
        {
            Debug.Log("勇者倒したったで！！！！");
            gameObject.SetActive(false);
        }
    }

    bool IsMouseOver()
    {
        //マウスの位置からRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //Rayが敵に当たったらTrueを返す
        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            return true;
        }

        return false;
    }
}
