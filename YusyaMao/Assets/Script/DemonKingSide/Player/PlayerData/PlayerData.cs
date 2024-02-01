using UnityEngine;

[CreateAssetMenu(menuName ="Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private int attackRange = 1;

    [SerializeField]
    private bool canUseSKill = true;

    [SerializeField]
    private int maxEnemyCount;

    private bool clearflag = false;

    public int ArrackPower 
    {   get { return attackPower; }

        set { attackPower = value; }
    }

    public int AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }

    public bool CanUseSKill
    {
        get { return canUseSKill; }
        set { canUseSKill = value; }
    }

    public bool ClearFlag
    {
        get { return clearflag; }
        set { clearflag = value; }
    }

    public int MaxEnemyCount
    {
        get { return maxEnemyCount; }
    }
}
