using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UIElements;

public class Skill_2 : MonoBehaviour
{
    [SerializeField]
    EnemyManeger enemyManeger;

    /// <summary>
    /// �G�X�V�G������
    /// ���̐����ƂɌ��������܂�
    /// </summary>
    [SerializeField]
    int Sword_Up_count;

    [Header("���̋����l")]
    public int SwordAttackPower;

    [Header("���̐�")]
    public int SwordNumber;

    [Header("���̒ǉ���")]
    public int SwordPlusNumber;


    public Skill_2Sword SwordAttack;

    [Header("���Ƃ���")]
    public GameObject SwordObject;

    [Header("�����X�s�[�h")]
    public float CreateSpeed;

    public GameObject AObject;
    public GameObject BObject;

    public CoolTime coolTime;

    [Header("�X�L�����")]
    public bool ReleaseFlg;

    private float time;

    /// <summary>
    /// ������
    /// </summary>
    private bool CreateFlg;

    /// <summary>
    /// �������錕�̐�
    /// </summary>
    private int count;

    /// <summary>
    /// ���J���`�F�[��
    /// </summary>
    [SerializeField]
    GameObject LockChain;

    /// <summary>
    /// �G�������A����ȏ�ŃX�L�����
    /// </summary>
    [SerializeField]
    int UncLock;

    private void Start()
    {
        ReleaseFlg = false;
        LockChain.SetActive(true);
    }

    private void Update()
    {

        if (!ReleaseFlg)
        {
            coolTime.ReCooldown();

            if (enemyManeger.GetKnockOutCount >= UncLock)
            {
                SkillOpen();
            }
            return;
        }


        if (CreateFlg)
        {
            if (GameManager.Instance.GetGameOperationFlg)
            {
                time += Time.deltaTime;
            }

            if (time > CreateSpeed && count > 0)
            {
                float randomX = Random.Range(AObject.transform.position.x, BObject.transform.position.x);
                float randomY = Random.Range(AObject.transform.position.y, BObject.transform.position.y);
                float randomZ = Random.Range(AObject.transform.position.z, BObject.transform.position.z);
                //���𐶐�
                GameObject sword = Instantiate(SwordObject,
                    new Vector3(randomX, randomY, randomZ), SwordObject.transform.rotation);
                sword.SetActive(true);
                count--;
            }
            else if (count == 0)
            {
                CreateFlg = false;
                coolTime.StartCooldown();
            }
        }
    }

    public void Exe()
    {
        if (!GameManager.Instance.GetGameOperationFlg || coolTime.CoolTimeFlg || !ReleaseFlg)
        {
            return;
        }

        CreateFlg = true;
        count = SwordNumber;
        Debug.Log("�X�L��2");
    }

    public void SkillOpen()
    {
        ReleaseFlg = true;
        LockChain.SetActive(false);
        coolTime.StartCooldown();
    }

}
