using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    EnemyManeger enemyGenerator;

    /// <summary>
    /// �U����
    /// </summary>
    [SerializeField]
    float AttackPower;

    public float GetAttackPower
    {
        get { return AttackPower; }
    }

    // Update is called once per frame
    void Update()
    {
        //�G�ɍU�����s
        if (Input.GetMouseButtonDown(0))
        {
            enemyGenerator.EnemyDamage(AttackPower);
        }
    }

    public void PowerUpdate(float addpower)
    {
        AttackPower += addpower;
        Debug.Log("uppo:" + AttackPower);
    }
}
