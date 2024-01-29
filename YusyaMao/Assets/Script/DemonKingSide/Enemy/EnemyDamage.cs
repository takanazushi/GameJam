using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField,Header("�G�̃f�[�^")]
    private EnemyData enemyData;

    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerData playerData;

    private int HP;

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
            Debug.Log(enemyData.name + "HP�F" + HP);
        }

        if (playerData == null)
        {
            Debug.LogError("�v���C���[�̃f�[�^����Ă܂����(>_<)");
        }
        else
        {
            Debug.Log("�v���C���[�̍U���́F" + playerData.ArrackPower);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�}�E�X���G�̏�ɂ����āA�N���b�N���ꂽ�Ƃ���HP�����炷
        if (Input.GetMouseButtonDown(0) && IsMouseOver())
        {
            HP -= playerData.ArrackPower;
            Debug.Log(enemyData.name + "HP�F" + HP);
        }

        if (HP <= 0)
        {
            Debug.Log("�E�ғ|���������ŁI�I�I�I");
            gameObject.SetActive(false);
        }
    }

    bool IsMouseOver()
    {
        //�}�E�X�̈ʒu����Ray���΂�
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        //Ray���G�ɓ���������True��Ԃ�
        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            return true;
        }

        return false;
    }
}
