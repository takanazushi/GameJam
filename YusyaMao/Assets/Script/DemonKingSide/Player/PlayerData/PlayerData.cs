using UnityEngine;

[CreateAssetMenu(menuName ="Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int attackPower = 1;

    [SerializeField]
    private int attackRange = 1;

    public int ArrackPower 
    {   get { return attackPower; }

        set { attackPower = value; }
    }

    public int AttackRange
    {
        get { return attackRange; }
        set { attackRange = value; }
    }
}
