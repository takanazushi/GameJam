using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Skill_Botton : MonoBehaviour
{
    [SerializeField]
    UnityEvent initEvent;

    public void OnBotton()
    {
        initEvent.Invoke();
    }
}
