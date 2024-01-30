using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    //���W�p�̕ϐ�
    Vector3 mousePos, worldPos;
    private bool hitEnemy;
    private bool hitfellow;

    [SerializeField,Header("Player�f�[�^")]
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
        //�}�E�X���W�̎擾
        mousePos = Input.mousePosition;
        //�X�N���[�����W�����[���h���W�ɕϊ�
        worldPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10f));
        //���[���h���W�����g�̍��W�ɐݒ�
        transform.position = worldPos;

        gameObject.transform.localScale = new Vector3(playerData.AttackRange, playerData.AttackRange, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g��Enemy�^�O
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
