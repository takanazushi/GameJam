using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowDamage : MonoBehaviour
{
    [SerializeField, Header("�����̃f�[�^")]
    private FellowData fellowData;

    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerData playerData;

    [SerializeField, Header("�U���͈�")]
    private GameObject AttackRange;

    [SerializeField, Header("�_���[�W�\�L�}�l�[�W��")]
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
            Debug.LogError("�����̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            keyName = fellowData.KeyNames[UnityEngine.Random.Range(0, fellowData.KeyNames.Length)];
            //Debug.Log(enemyData.name + "HP�F" + HP);
            Debug.Log(fellowData.name + "�L�[�F" + keyName);
        }

        if (playerData == null)
        {
            Debug.LogError("�v���C���[�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            //Debug.Log("�v���C���[�̍U���́F" + playerData.ArrackPower);
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

        //�}�E�X���G�̏�ɂ����āA�N���b�N���ꂽ�Ƃ���HP�����炷
        if (mouseFollow.HitFellow)
        {
            if (keyName == "Click")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    gameObject.SetActive(false);
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(0.5f);
                    // Debug.Log(enemyData.name + "HP�F" + HP);
                }
            }
            else
            {
                Debug.Log("KeyCode" + keyCode);

                if (Input.GetKeyDown(keyCode))
                {
                    // Debug.Log(keyCode + "������");
                    gameObject.SetActive(false);
                    number_Test.Init(playerData.ArrackPower, 1);
                    number_Test.DestroyObject(1.0f);
                    // Debug.Log(enemyData.name + "HP�F" + HP);
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
