using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Skill_3 : MonoBehaviour
{
    [SerializeField]
    EnemyManeger enemyManeger;

    public Hero playerData;
    public Skill_1MagicLine skill_1MagicLine;
    public Skill_2Sword skill_2Sword;

    public CoolTime CoolTime;

    [Header("スキル解放")]
    public bool Release;

    public float BuffPower;
    public float BuffTime;

    [Header("スキル解放")]
    public bool ReleaseFlg;

    [SerializeField]
    GameObject effect;

    /// <summary>
    /// 未開放チェーン
    /// </summary>
    [SerializeField]
    GameObject LockChain;

    /// <summary>
    /// 敵討伐数、これ以上でスキル解放
    /// </summary>
    [SerializeField]
    int UncLock;

    [SerializeField]
    int Attack_Power;

    private void Start()
    {
        ReleaseFlg = false;
        LockChain.SetActive(true);
    }

    private void Update()
    {
        if (!ReleaseFlg)
        {
            CoolTime.ReCooldown();

            if (enemyManeger.GetKnockOutCount >= UncLock)
            {
                SkillOpen();
            }
            return;
        }

    }

    public void Exe()
    {
        if (!GameManager.Instance.GetGameOperationFlg || CoolTime.CoolTimeFlg || !ReleaseFlg) 
        {
            return;
        }
        CoolTime.StartCooldown();


        //Invoke(nameof(Buff), BuffTime);
        //playerData.PowerUpdate(playerData.GetAttackPower * BuffPower);
        //skill_1MagicLine.AttackPower *= BuffPower;
        //skill_2Sword.AttackPower *= BuffPower;
        effect.SetActive(true);

        enemyManeger.Enemy_AllDamage(Attack_Power);


        Debug.Log("スキル3");
    }

    public void Buff()
    {
        playerData.PowerUpdate(-(playerData.GetAttackPower / BuffPower));
        skill_1MagicLine.AttackPower -= skill_1MagicLine.AttackPower / BuffPower;
        skill_2Sword.AttackPower -= skill_2Sword.AttackPower / BuffPower;

    }

    public void SkillOpen()
    {
        ReleaseFlg = true;
        LockChain.SetActive(false);
        CoolTime.StartCooldown();
    }

}
