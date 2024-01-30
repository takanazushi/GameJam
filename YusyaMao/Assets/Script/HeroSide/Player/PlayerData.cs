using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [SerializeField]
    EnemyManeger enemyGenerator;

    /// <summary>
    /// çUåÇóÕ
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
        //ìGÇ…çUåÇé¿çs
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
