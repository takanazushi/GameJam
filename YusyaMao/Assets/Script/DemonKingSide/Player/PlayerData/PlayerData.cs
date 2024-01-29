using UnityEngine;

[CreateAssetMenu(menuName ="Player")]
public class PlayerData : ScriptableObject
{
    [SerializeField]
    private int attackPower = 1;

    public int ArrackPower 
    {   get { return attackPower; }

        set { attackPower = value; }
    }
}
