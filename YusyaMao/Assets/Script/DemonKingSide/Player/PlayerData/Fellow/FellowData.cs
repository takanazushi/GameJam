using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Fellow")]
public class FellowData : ScriptableObject
{
    [SerializeField]
    private string FellowName;

    [SerializeField]
    private string[] keyNames;

    [SerializeField]
    private float speed;

    private string key;

    public string[] KeyNames { get { return keyNames; } }

    public float Speed { get { return speed; }}

}
