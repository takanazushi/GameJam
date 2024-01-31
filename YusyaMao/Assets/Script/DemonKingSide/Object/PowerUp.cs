using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    [SerializeField, Header("プレイヤー")]
    private GameObject Player;

    [SerializeField,Header("ポーションのデータ")]
    private PortionData portionData;

    [SerializeField, Header("移動速度")]
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
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.AttackPowerUp5:
                    playerData.ArrackPower += 5;
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.BigSkillRecovery:
                    playerData.CanUseSKill = true;
                    gameObject.SetActive(false);
                    break;

                case PortionData.PotionEffect.RangeExpansion:
                    if (playerData.AttackRange !=11)
                    {
                        playerData.AttackRange += 1;
                    }
                    gameObject.SetActive(false);
                    break;
            }
        }
    }

    // 子オブジェクトの移動を開始するメソッド
    public void StartMoving()
    {
        isMoving = true;
    }
}
