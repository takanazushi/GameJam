using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("�G�̃f�[�^")]
    private EnemyData enemyData;

    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerData playerData;

    [SerializeField, Header("�U���͈�")]
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
            Debug.LogError("�G�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            HP = enemyData.MaxHP;
            keyName = enemyData.KeyNames[UnityEngine.Random.Range(0, enemyData.KeyNames.Length)];
            //Debug.Log(enemyData.name + "HP�F" + HP);
           // Debug.Log(enemyData.name + "�L�[�F" + keyName);
        }

        if (playerData == null)
        {
           // Debug.LogError("�v���C���[�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            //Debug.Log("�v���C���[�̍U���́F" + playerData.ArrackPower);
        }

        if (AttackRange == null)
        {
            Debug.LogError("�U���͈͂̂Ƃ���ɉ��������Ă܂���(>_<)");
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

        //�}�E�X���G�̏�ɂ����āA�N���b�N���ꂽ�Ƃ���HP�����炷
        if (mouseFollow.HitEnemy)
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    HP -= playerData.ArrackPower;
                   // Debug.Log(enemyData.name + "HP�F" + HP);
                }
            }
            else
            {
                Debug.Log("KeyCode" + keyCode);

                if (Input.GetKeyDown(keyCode))
                {
                   // Debug.Log(keyCode + "������");
                    HP -= playerData.ArrackPower;
                   // Debug.Log(enemyData.name + "HP�F" + HP);
                }
            }
        }
       

        if (HP <= 0)
        {
            Debug.Log("�E�ғ|���������ŁI�I�I�I");
            gameObject.SetActive(false);
        }
    }

    //bool IsMouseOver()
    //{
    //    //�}�E�X�̈ʒu����Ray���΂�
    //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //    RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

    //    //Ray���G�ɓ���������True��Ԃ�
    //    if (hit.collider != null && hit.collider.gameObject == this.gameObject)
    //    {
    //        Debug.Log("�}�E�X�J�[�\�����������Ă܂��I");
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
