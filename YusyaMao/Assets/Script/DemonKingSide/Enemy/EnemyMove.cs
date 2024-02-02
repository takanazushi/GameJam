using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float speed = 1.0f;

    [SerializeField, Header("�G�f�[�^")]
    private EnemyData enemyData;

    [SerializeField,Header("�v���C���[�f�[�^")]
    private PlayerDoragonData playerData;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGetTime_flg)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������");

        if (collision.gameObject.CompareTag("Line"))
        {
            speed = 0;
            Debug.Log("�ؗ�");

            StartCoroutine(DealDamageOverTime(5f));
        }
    }

    private IEnumerator DealDamageOverTime(float interval)
    {
        while (true)
        {
            if (!GameManager.Instance.IsGetTime_flg)
            {
                yield return null;
                continue;
            }

            playerData.PlayerHP -= 1;
            yield return new WaitForSeconds(interval);
        }
    }

}
