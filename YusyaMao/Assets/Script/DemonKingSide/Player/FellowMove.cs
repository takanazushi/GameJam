using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowMove : MonoBehaviour
{
    [SerializeField, Header("�����f�[�^")]
    private FellowData fellowData;

    [SerializeField, Header("�|�[�V����")]
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
        // �J�����O�ɏo����SetActive��False�ɂ���
        gameObject.SetActive(false);
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
