using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class Skill_1MagicLine : MonoBehaviour
{
    [SerializeField]
    EnemyManeger EnemyManeger;
    
    //攻撃力
    [SerializeField]
    public float AttackPower;

    string[] HitEnemyname = new string[25];
    int HitCount;

    [SerializeField]
    GameObject MagicCircle;

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool hit = true;
        foreach (var item in HitEnemyname)
        {
            if (item == collision.name) 
            {
                hit = false;
            }
        }

        if (hit&& HitCount<=24)
        {
            HitEnemyname[HitCount] = collision.name;
            EnemyManeger.EnemyDamage(collision.transform, AttackPower);
            HitCount++;
        }

    }

    //アニメーション終了後表示終了
    public void OnAnimationEnd()
    {
        gameObject.SetActive(false);
        HitCount = 0;
        HitEnemyname = new string[10];
        MagicCircle.SetActive(false);
    }
}
