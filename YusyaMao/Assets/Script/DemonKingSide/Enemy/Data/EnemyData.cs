using UnityEngine;

[CreateAssetMenu(menuName = "Enemy")] 
public class EnemyData : ScriptableObject
{
    [SerializeField]
    private string enemyName;

    [SerializeField]
    private int maxHP;

    public int MaxHP { get { return maxHP; } }
}
