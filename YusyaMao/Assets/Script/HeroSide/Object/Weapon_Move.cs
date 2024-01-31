using UnityEngine;

public class Weapon_Move : MonoBehaviour
{
    enum Weapon_MoveType
    {
        //�����Ȃ�
        Not,

        /// <summary>
        /// �G�Ɍ������Ĉ꒼���ɔ�ь��̈ʒu�ɖ߂�
        /// </summary>
        Enemy_StraightLine,

    }


    [SerializeField, Header("�ړ��^�C�v")]
    Weapon_MoveType MoveType;


    [Header("�����ʒu")]
    private Vector3 StartPosition;

    [Header("�ړ����x")]
    public float Speed;

    //�ړ��J�n�t���O
    private bool MoveStartFlg;
    //�N�[���_�E���t���O
    private bool CoolDownFlg;

    //�N���b�N���̃}�E�X�ʒu
    private Vector3 MousePosition;

    //�ړ��ʒu
    private Vector3 MovePosition;

    //�G���X�g
    [SerializeField]
    private EnemyManeger Enemy_maneger;

    /// <summary>
    /// ���V���[�V�����X�N���v�g
    /// </summary>
    Enemy_Fluffy _Fluffy;

    private void Start()
    {
        StartPosition = transform.position;
        _Fluffy = GetComponent<Enemy_Fluffy>();
    }

    void Update()
    {
        //�����ʒu����N���b�N�ʒu�܂�
        if (MoveStartFlg && !CoolDownFlg)
        {

            switch (MoveType)
            {
                case Weapon_MoveType.Not:
                    break;
                case Weapon_MoveType.Enemy_StraightLine:
                    transform.position = Vector3.MoveTowards(
                     transform.position, MovePosition, Speed * Time.deltaTime);

                    if (_Fluffy)
                    {
                        _Fluffy.SetinitialY(transform.position.y);
                    }

                    if (transform.position == MovePosition)
                    {
                        CoolDownFlg = true;
                        MoveStartFlg = false;
                    }
                    break;
            }
        }
        //�N���b�N�ʒu���珉���ʒu�܂�
        if (!MoveStartFlg && CoolDownFlg)
        {
            switch (MoveType)
            {
                case Weapon_MoveType.Not:
                    break;
                case Weapon_MoveType.Enemy_StraightLine:
                    transform.position = Vector3.MoveTowards(
                        transform.position, StartPosition, Speed * Time.deltaTime);

                    if (_Fluffy)
                    {
                        _Fluffy.SetinitialY(transform.position.y);
                    }

                    if (transform.position == StartPosition)
                    {
                        CoolDownFlg = false;
                    }
                    break;
            }

        }
    }

    public void MoveStart()
    {
        bool flg = true;
        //�X�N���[�����W�����[���h���W�ɕϊ�
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //�N���b�N�ʒu�����ԋ߂��I�u�W�F�N�g�����X�g���猟��
        Vector3 NearbyEnemy = Enemy_maneger.EnemyPointSearch(MousePosition);

        if (MousePosition == NearbyEnemy) 
        {
            flg = false;
        }
        else
        {
            //�N���b�N�ʒu�����ԋ߂��I�u�W�F�N�g�Ɉړ�
            MovePosition = NearbyEnemy;

        }



        if (NearbyEnemy != null&& flg)
        {
            if (!MoveStartFlg && !CoolDownFlg)
            {
                MoveStartFlg = true;
            }

        }


    }

}


