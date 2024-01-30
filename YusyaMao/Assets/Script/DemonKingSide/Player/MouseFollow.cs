using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    //座標用の変数
    Vector3 mousePos, worldPos;
    private bool hitEnemy;
    private bool hitfellow;

    [SerializeField,Header("Playerデータ")]
    private PlayerData playerData;

    public bool HitEnemy
    {
        get { return hitEnemy; }
    }

    public bool HitFellow
    {
        get { return hitfellow; }
    }

    private void Start()
    {
        gameObject.transform.localScale = new Vector3(playerData.AttackRange, playerData.AttackRange, 0);
    }

    void Update()
    {
        //マウス座標の取得
        mousePos = Input.mousePosition;
        //スクリーン座標をワールド座標に変換
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //ワールド座標を自身の座標に設定
        transform.position = worldPos;

        gameObject.transform.localScale = new Vector3(playerData.AttackRange, playerData.AttackRange, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトがEnemyタグ
        if (collision.gameObject.tag == "Enemy")
        {
            hitEnemy = true;
        }

        if(collision.gameObject.tag== "Fellow")
        {
            hitfellow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            hitEnemy = false;
        }

        if (collision.gameObject.tag == "Fellow")
        {
            hitfellow = false;
        }
    }
}
