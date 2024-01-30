using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("敵のデータ")]
    private EnemyData enemyData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    private int HP;
    private string keyName;
    private KeyCode keyCode;


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
            keyName = enemyData.KeyNames[UnityEngine.Random.Range(0, enemyData.KeyNames.Length)];
            Debug.Log(enemyData.name + "HP：" + HP);
            Debug.Log(enemyData.name + "キー：" + keyName);
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
        KeyCodeGet();

        //マウスが敵の上にあって、クリックされたときにHPを減らす
        if (keyName == "Click")
        {
            if (Input.GetMouseButtonDown(0) && IsMouseOver())
            {
                HP -= playerData.ArrackPower;
                Debug.Log(enemyData.name + "HP：" + HP);
            }
        }
        else
        {
            Debug.Log("KeyCode" + keyCode);

            if (Input.GetKeyDown(keyCode) && IsMouseOver())
            {
                HP -= playerData.ArrackPower;
                Debug.Log(enemyData.name + "HP：" + HP);
            }
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

    private void KeyCodeGet()
    {
        if (keyName == "Click")
        {
            return;
        }
        else
        {
            keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), keyName);
        }
       
    }
}
