using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("敵のデータ")]
    private EnemyData enemyData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    [SerializeField, Header("攻撃範囲")]
    private GameObject AttackRange;

    private int HP;
    private string keyName;
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
           // Debug.Log(enemyData.name + "キー：" + keyName);
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
            Debug.LogError("攻撃範囲のところに何も入ってません(>_<)");
        }
        else
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

    //bool IsMouseOver()
    //{
    //    //マウスの位置からRayを飛ばす
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

    //    //Rayが敵に当たったらTrueを返す
    //    if (hit.collider != null && hit.collider.gameObject == this.gameObject)
    //    {
    //        Debug.Log("マウスカーソルが当たってます！");
    //        return true;
    //    }

    //    return false;
    //}

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
