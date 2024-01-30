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

    private string keyName;

    public int MaxHP { get { return maxHP; } }

    int index;

    public string KeyName 
    { get { return keyName=keyNames[index = UnityEngine.Random.Range(0, keyNames.Length)]; } }

}
