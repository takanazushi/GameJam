using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowMove : MonoBehaviour
{
    [SerializeField, Header("味方データ")]
    private FellowData fellowData;

    [SerializeField, Header("ポーション")]
    private GameObject portion;


    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGetTime_flg)
        {
            transform.Translate(-fellowData.Speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnBecameInvisible()
    {
        // カメラ外に出たらSetActiveをFalseにする
        gameObject.SetActive(false);
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
