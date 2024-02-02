using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerDoragonData playerData;

    [SerializeField, Header("���C��Camera")]
    private Camera mainCamera;

    [SerializeField]
    private GameObject SKillEffect;

    [SerializeField]
    private AudioClip SkillSE;

    private AudioSource audioSource;

    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (playerData.PlayerHP <= 0)
        {
            animator.SetBool("Is_Down", true);
           
        }
    }

    void  DownEnd()
    {
        playerData.GameOverFlag = true;
        GameManager.Instance.IsGetTime_flg = false;
    }

    public void UseSkill()
    {
        if (!playerData.CanUseSKill)
        {
            return;
        }

        if (SKillEffect.activeSelf == false)
        {
            SKillEffect.SetActive(true);
            audioSource.PlayOneShot(SkillSE);
        }

        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            // �G�l�~�[�̈ʒu���r���[�|�[�g���W�ɕϊ�
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(enemy.transform.position);

            // �r���[�|�[�g���W��(0, 0)����(1, 1)�͈͓̔��ɂ��邩�ǂ������m�F
            if (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1)
            {
                enemy.SetActive(false);
            }
        }

        playerData.CanUseSKill = false;
    }
}
