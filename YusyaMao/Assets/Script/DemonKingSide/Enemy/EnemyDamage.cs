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
            Debug.LogError("�G�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            HP = enemyData.MaxHP;
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
    }

    // Update is called once per frame
    void Update()
    {
        KeyCodeGet();

        //�}�E�X���G�̏�ɂ����āA�N���b�N���ꂽ�Ƃ���HP�����炷
        if (mouseFollow.HitEnemy&&mouseFollow.GetEnemyList.Contains(this.gameObject))
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    HP -= playerData.ArrackPower;
                    number_Test.Init(playerData.ArrackPower,1);
                    number_Test.DestroyObject(0.5f);
                }
            }
            else
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
       

        if (HP <= 0)
        {
            Debug.Log("�E�ғ|���������ŁI�I�I�I");
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
