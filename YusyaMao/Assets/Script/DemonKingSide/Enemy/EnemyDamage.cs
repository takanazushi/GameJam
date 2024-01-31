using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("敵のデータ")]
    private EnemyData enemyData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    [SerializeField, Header("攻撃範囲")]
    private GameObject AttackRange;

    [SerializeField,Header("ダメージ表記マネージャ")]
    private Number_test number_Test;

    private int HP;
    private string keyName;

    public string KeyName
    {
        get { return keyName; }
    }

    public int GetHP
    {
        get { return HP; }
    }

    private KeyCode keyCode;

    private MouseFollow mouseFollow;

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
            //Debug.Log(enemyData.name + "HP：" + HP);
            Debug.Log(enemyData.name + "キー：" + keyName);
        }

        if (playerData == null)
        {
           // Debug.LogError("プレイヤーのデータ入れてませんよ(>_<)");
        }
        else
        {
            //Debug.Log("プレイヤーの攻撃力：" + playerData.ArrackPower);
        }

        if (AttackRange == null)
        {
            AttackRange = GameObject.Find("Cursor");
            Debug.LogError("攻撃範囲のところに何も入ってません(>_<)");
        }

        if (AttackRange != null)
        {
            mouseFollow = AttackRange.GetComponent<MouseFollow>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyCodeGet();

        //マウスが敵の上にあって、クリックされたときにHPを減らす
        if (mouseFollow.HitEnemy)
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    HP -= playerData.ArrackPower;
                    number_Test.Init(playerData.ArrackPower,1);
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
                    HP -= playerData.ArrackPower;
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(1.0f);
                    // Debug.Log(enemyData.name + "HP：" + HP);
                }
            }
        }
       

        if (HP <= 0)
        {
            Debug.Log("勇者倒したったで！！！！");
            gameObject.SetActive(false);
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
