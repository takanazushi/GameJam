using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fluffy : MonoBehaviour
{
    /// <summary>
    /// ‰ŠúYÀ•W•Û
    /// </summary>
    [Header("‰ŠúY")]
    float Amplitude;

    private void Start()
    {
        Amplitude = this.transform.position.y;
    }

    private void Update()
    {
        transform.position = new Vector2(
            transform.position.x, Amplitude + Mathf.PingPong(Time.time / 3, 0.3f));
    }
}
