using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField, Header("プレイヤーのデータ")]
    private PlayerData playerData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった");

        if (collision.gameObject.CompareTag("Line"))
        {
            playerData.ArrackPower += 1;
            Debug.Log("プレイヤー強化したぞ");
        }
    }
}
