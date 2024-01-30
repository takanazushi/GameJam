using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowMove : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float speed = 1.0f;

    [SerializeField, Header("ポーション")]
    private GameObject portion;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("当たった");

        if (collision.gameObject.CompareTag("Line"))
        {
            // 子オブジェクトの移動を開始
            portion.GetComponent<PowerUp>().StartMoving();
        }
    }
}
