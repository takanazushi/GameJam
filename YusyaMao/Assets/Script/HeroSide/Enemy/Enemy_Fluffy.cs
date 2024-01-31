using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fluffy : MonoBehaviour
{
    /// <summary>
    /// 初期Y座標保持
    /// </summary>
    [Header("初期Y")]
    float initialY;

    private void Start()
    {
        initialY = transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector2(
            transform.position.x, initialY + Mathf.PingPong(Time.time / 3, 0.3f));
    }

    public void SetinitialY(float y)
    {
        initialY= y;
    }
}
