using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������");

        if (collision.gameObject.CompareTag("Line"))
        {
            playerData.ArrackPower += 1;
            Debug.Log("�v���C���[����������");
        }
    }
}
