using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("敵のデータ")]
    private EnemyData enemyData;

    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerDoragonData playerData;

    [SerializeField, Header("攻撃範囲")]
    private GameObject AttackRange;

    [SerializeField,Header("ダメージ表記マネージャ")]
    private Number_test number_Test;

    private Animator animator;

    [SerializeField]
    GameObject damageEffect;

    [SerializeField]
    private AudioClip damageSE;

    private int StartHP;

    private int HP;
    private string keyName;

    private AudioSource audioSource;

    public string KeyName
    {
        get { return keyName; }
    }

    public int GetHP
    {
        get { return HP; }
    }

    public int GetStartHP
    {
        get { return StartHP; }
    }

    private KeyCode keyCode;

    private MouseFollow mouseFollow;

    private int previousHP;

    // Start is called before the first frame update
    void Start()
    {
        if (enemyData == null)
        {
            Debug.LogError("敵のデータいれてませんよ(>_<)");
        }
        else
        {
            HP = UnityEngine.Random.Range(enemyData.MinHP, enemyData.MaxHP);
            keyName = enemyData.KeyNames[UnityEngine.Random.Range(0, enemyData.KeyNames.Length)];
            Debug.Log(enemyData.name + "キー：" + keyName);
        }

        if (playerData == null)
        {
           Debug.LogError("プレイヤーのデータ入れてませんよ(>_<)");
        }

        if (AttackRange == null)
        {
            AttackRange = GameObject.Find("Cursor");
        }

        if (AttackRange != null)
        {
            mouseFollow = AttackRange.GetComponent<MouseFollow>();
        }

        animator=GetComponent<Animator>();

        previousHP = HP;

        StartHP = HP;

        audioSource=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyCodeGet();

        //マウスが敵の上にあって、クリックされたときにHPを減らす
        if (mouseFollow.HitEnemy && mouseFollow.GetEnemyList.Contains(this.gameObject) && GameManager.Instance.IsGetTime_flg) 
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    HP -= playerData.ArrackPower;
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(0.5f);
                }
            }
            else if (keyName != "Click")
            {
                Debug.Log("KeyCode" + keyCode);

                if (Input.GetKeyDown(keyCode))
                {
                    HP -= playerData.ArrackPower;
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(1.0f);
                    
                }
            }
        }

        if (HP < previousHP)
        {
            if (damageEffect.activeSelf==false)
            {
                damageEffect.SetActive(true);
                audioSource.PlayOneShot(damageSE);
                animator.SetBool("Is_Damage", true);
            }

            Debug.Log("HPが減りました！");
           
        }
        else
        {
            animator.SetBool("Is_Damage", false);
        }

        // 現在のHPを保存
        previousHP = HP;


        if (HP <= 0)
        {
            StartCoroutine(PlayerDieAnimarion());
            Debug.Log("勇者倒したったで！！！！");
           
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

    IEnumerator PlayerDieAnimarion()
    {
        animator.SetBool("Is_Damage", false);
        animator.SetBool("Is_Down", true);

        yield return new WaitForSeconds(1.8f);

        gameObject.SetActive(false);
    }

}


