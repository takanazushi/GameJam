using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Potion")]
public class PortionData : ScriptableObject
{
    public enum PotionEffect
    {
        AttackPowerUp1,
        AttackPowerUp5,
        BigSkillRecovery,
        RangeExpansion
    }

    [SerializeField]
    private string potionName;

    [SerializeField]
    private PotionEffect effect;

    public PotionEffect Effect
    {
        get { return effect; }
    }
}
