using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_2Sword : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;

    public float AttackPower;
    public float DestroyTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("ÇªÅ[Ç«");
            EnemyManeger.EnemyDamage(collision.transform, AttackPower);

            //àÍíËéûä‘å„Ç…è¡ãé
            Invoke(nameof(OnDestroy), DestroyTime);
        }
    }
    private void Update()
    {
        if (!GameManager.Instance.GetGameOperationFlg)
        {
            return;
        }
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPoint.y < -135)
        {
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }
}

