using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float speed = 1.0f;

    [SerializeField, Header("敵データ")]
    private EnemyData enemyData;

    [SerializeField,Header("プレイヤーデータ")]
    private PlayerData playerData;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

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
            speed = 0;
            Debug.Log("滞留");
        }
    }
}
