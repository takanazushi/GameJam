using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Skill_1 : MonoBehaviour
{
    [Header("���@�w�I�u�W�F�N�g")]
    public GameObject MagicCircleObject;
    [Header("���C���I�u�W�F�N�g")]
    public GameObject MagicLineObject;

    [Header("���C���\���X�s�[�h")]
    public float LineSpeed;

    public CoolTime CoolTime;

    /// <summary>
    /// �X�L������t���Otrue:����ς�
    /// </summary>
    [Header("�X�L�����")]
    public bool ReleaseFlg;

    /// <summary>
    /// �g�p���Ă��Ȃ����̌o�ߎ���
    /// </summary>
    float countTime;

    private void Start()
    {
        MagicLineObject.gameObject.SetActive(false);
        countTime = 0f;
        SkillOpen();
    }


    public void Exe()
    {
        if (!GameManager.Instance.GetGameOperationFlg||CoolTime.CoolTimeFlg || !ReleaseFlg)
        {
            return;
        }

        //�N�[���_�E���X�^�[�g
        CoolTime.StartCooldown();

        //���@�w�\��
        //���b�N�������ꂽ���ڂ̖��@�w�\��
        MagicCircleObject.gameObject.SetActive(true);

        //���C���\��
        MagicLineObject.gameObject.SetActive(true);

        if (countTime >= LineSpeed)
        {
            if (!MagicLineObject.gameObject.activeSelf)
            {
                //Line�\��
                MagicLineObject.gameObject.SetActive(true);
            }
            else
            {
                countTime = 0;
            }

        }

        countTime += Time.deltaTime;


        Debug.Log("�X�L��1");
    }


    public void SkillOpen()
    {
        ReleaseFlg=true;
    }

}
