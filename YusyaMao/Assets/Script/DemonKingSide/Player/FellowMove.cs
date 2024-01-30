using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowMove : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float speed = 1.0f;

    [SerializeField, Header("�|�[�V����")]
    private GameObject portion;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("��������");

        if (collision.gameObject.CompareTag("Line"))
        {
            // �q�I�u�W�F�N�g�̈ړ����J�n
            portion.GetComponent<PowerUp>().StartMoving();
        }
    }
}
