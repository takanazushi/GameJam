using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")] 
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyName;

    [SerializeField]
    private int maxHP;

    [SerializeField]
    private string[] keyNames;

    [SerializeField]
    private int attackPower;

    private string key;

    public int MaxHP { get { return maxHP; } }

    public string[] KeyNames {  get { return keyNames; } }

    public int AttackPower { get { return attackPower; } }

}
