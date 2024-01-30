using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerData playerData;

    [SerializeField, Header("�v���C���[")]
    private GameObject Player;

    [SerializeField,Header("�|�[�V�����̃f�[�^")]
    private PortionData portionData;

    [SerializeField, Header("�ړ����x")]
    private float Speed = 2.0f;

    private bool isMoving = false;

    private void Update()
    {
        if (isMoving)
        {
            Vector3 direction = (Player.transform.position - transform.position).normalized;
            transform.position += direction * Speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player)
        {

            switch (portionData.Effect)
            {
                case PortionData.PotionEffect.AttackPowerUp1:
                    playerData.ArrackPower += 1;
                    Debug.Log("�v���C���[��1����������");
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.AttackPowerUp5:
                    playerData.ArrackPower += 5;
                    Debug.Log("�v���C���[��5����������");
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.BigSkillRecovery:
                    Debug.Log("�K�E�Z���g����悤�ɂ������I");
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.RangeExpansion:
                    if (playerData.AttackRange !=11)
                    {
                        playerData.AttackRange += 1;
                        Debug.Log("�U���͈͂��L��������");
                    }
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    // �q�I�u�W�F�N�g�̈ړ����J�n���郁�\�b�h
    public void StartMoving()
    {
        isMoving = true;
    }
}
