using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Manager : MonoBehaviour
{
    [Header("�{�X�o��")]
    public bool CreateBoss;

    [Header("�G���̃v���n�u")]
    public GameObject EnemyMini;

    [Header("���X�|�[������G�̐�")]
    public int Menber;

    [Header("���X�|�[���Ԋu")]
    public int RespawnTime;

    private float CountTime;


    //�q�I�u�W�F�N�g�̃��X�g
    private List<GameObject> EnemyMiniList = new List<GameObject>();

    private void Update()
    {
        //��������0�Ȃ�G�𐶐�
        if (EnemyMiniList.Count < Menber && CountTime <= 0) 
        {
            //�G�𐶐�
            SpawnEnemyMini();
            
            //���X�|�[���^�C�������Z�b�g�i�����_���ɂ��Ă��������ȁj
            CountTime = RespawnTime;
        }
        else
        {
            CountTime -= Time.deltaTime;
        }
        //�G�����X�g����폜
        RemoveEnemyMini();
    }

    // �G�̐���
    private void SpawnEnemyMini()
    {
        //�v���n�u����G�𐶐�
        GameObject newEnemy = Instantiate(EnemyMini, transform.position, Quaternion.identity);
        EnemyMiniList.Add(newEnemy);
    }

    //�|���ꂽ�iHP��0�ɂȂ����j�G�����X�g����폜
    private void RemoveEnemyMini()
    {
        EnemyMiniList.RemoveAll(enemy => enemy.GetComponent<Enemy_Mini>().HP <= 0);
    }
}
