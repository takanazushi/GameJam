using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("�G�̃f�[�^")]
    private EnemyData enemyData;

    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerDoragonData playerData;

    [SerializeField, Header("�U���͈�")]
    private GameObject AttackRange;

    [SerializeField,Header("�_���[�W�\�L�}�l�[�W��")]
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
            Debug.LogError("�G�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            HP = UnityEngine.Random.Range(enemyData.MinHP, enemyData.MaxHP);
            keyName = enemyData.KeyNames[UnityEngine.Random.Range(0, enemyData.KeyNames.Length)];
            Debug.Log(enemyData.name + "�L�[�F" + keyName);
        }

        if (playerData == null)
        {
           Debug.LogError("�v���C���[�̃f�[�^����Ă܂����(>_<)");
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

        //�}�E�X���G�̏�ɂ����āA�N���b�N���ꂽ�Ƃ���HP�����炷
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

            Debug.Log("HP������܂����I");
           
        }
        else
        {
            animator.SetBool("Is_Damage", false);
        }

        // ���݂�HP��ۑ�
        previousHP = HP;


        if (HP <= 0)
        {
            StartCoroutine(PlayerDieAnimarion());
            Debug.Log("�E�ғ|���������ŁI�I�I�I");
           
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


