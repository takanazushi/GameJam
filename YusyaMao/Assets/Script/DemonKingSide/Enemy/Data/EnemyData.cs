using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")] 
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyName;

    [SerializeField]
    private int maxHP;

    [SerializeField]
    private int minHP;

    [SerializeField]
    private string[] keyNames;

    [SerializeField]
    private int attackPower;

    private string key;

    public int MaxHP { get { return maxHP; } }

    public int MinHP { get { return minHP; } }

    public string[] KeyNames {  get { return keyNames; } }

    public int AttackPower { get { return attackPower; } }

}
