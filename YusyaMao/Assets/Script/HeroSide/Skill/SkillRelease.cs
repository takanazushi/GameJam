using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRelease : MonoBehaviour
{
    public GameObject[] skillObjects; // 子オブジェクトを格納する配列

    void Start()
    {
        // 子オブジェクトを取得して配列に格納
        skillObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            skillObjects[i] = transform.GetChild(i).gameObject;
        }

    }
}
