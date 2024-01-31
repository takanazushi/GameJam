using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowDamage : MonoBehaviour
{
    [SerializeField, Header("味方のデータ")]
    private FellowData fellowData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    [SerializeField, Header("攻撃範囲")]
    private GameObject AttackRange;

    [SerializeField, Header("ダメージ表記マネージャ")]
    private Number_test number_Test;

    private string keyName;

    public string KeyName
    {
        get { return keyName; }
    }

    private KeyCode keyCode;

    private MouseFollow mouseFollow;

    void Start()
    {
        if (fellowData == null)
        {
            Debug.LogError("味方のデータいれてませんよ(>_<)");
        }
        else
        {
            keyName = fellowData.KeyNames[UnityEngine.Random.Range(0, fellowData.KeyNames.Length)];
            //Debug.Log(enemyData.name + "HP：" + HP);
            Debug.Log(fellowData.name + "キー：" + keyName);
        }

        if (playerData == null)
        {
            Debug.LogError("プレイヤーのデータ入れてませんよ(>_<)");
        }
        else
        {
            //Debug.Log("プレイヤーの攻撃力：" + playerData.ArrackPower);
        }

        if (AttackRange == null)
        {
            AttackRange = GameObject.Find("Cursor");
        }

        if (AttackRange != null)
        {
            mouseFollow = AttackRange.GetComponent<MouseFollow>();
        }
    }

    void Update()
    {
        KeyCodeGet();

        //マウスが敵の上にあって、クリックされたときにHPを減らす
        if (mouseFollow.HitFellow)
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameObject.SetActive(false);
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(0.5f);
                    // Debug.Log(enemyData.name + "HP：" + HP);
                }
            }
            else
            {
                Debug.Log("KeyCode" + keyCode);

                if (Input.GetKeyDown(keyCode))
                {
                    // Debug.Log(keyCode + "押した");
                    gameObject.SetActive(false);
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(1.0f);
                    // Debug.Log(enemyData.name + "HP：" + HP);
                }
            }
        }
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
