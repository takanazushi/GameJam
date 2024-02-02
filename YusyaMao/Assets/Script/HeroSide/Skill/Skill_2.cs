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
    /// 敵更新敵討伐数
    /// この数ごとに剣が増えます
    /// </summary>
    [SerializeField]
    int Sword_Up_count;

    [Header("剣の強化値")]
    public int SwordAttackPower;

    [Header("剣の数")]
    public int SwordNumber;

    [Header("剣の追加数")]
    public int SwordPlusNumber;


    public Skill_2Sword SwordAttack;

    [Header("落とす剣")]
    public GameObject SwordObject;

    [Header("生成スピード")]
    public float CreateSpeed;

    public GameObject AObject;
    public GameObject BObject;

    public CoolTime coolTime;

    [Header("スキル解放")]
    public bool ReleaseFlg;

    private float time;

    /// <summary>
    /// 発動中
    /// </summary>
    private bool CreateFlg;

    /// <summary>
    /// 生成する剣の数
    /// </summary>
    private int count;

    /// <summary>
    /// 未開放チェーン
    /// </summary>
    [SerializeField]
    GameObject LockChain;

    /// <summary>
    /// 敵討伐数、これ以上でスキル解放
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
                //剣を生成
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
        Debug.Log("スキル2");
    }

    public void SkillOpen()
    {
        ReleaseFlg = true;
        LockChain.SetActive(false);
        coolTime.StartCooldown();
    }

}
