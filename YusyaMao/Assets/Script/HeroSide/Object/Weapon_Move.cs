using UnityEngine;

public class Weapon_Move : MonoBehaviour
{
    enum Weapon_MoveType
    {
        //動かない
        Not,

        /// <summary>
        /// 敵に向かって一直線に飛び元の位置に戻る
        /// </summary>
        Enemy_StraightLine,

    }


    [SerializeField, Header("移動タイプ")]
    Weapon_MoveType MoveType;


    [Header("初期位置")]
    private Vector3 StartPosition;

    [Header("移動速度")]
    public float Speed;

    //移動開始フラグ
    private bool MoveStartFlg;
    //クールダウンフラグ
    private bool CoolDownFlg;

    //クリック時のマウス位置
    private Vector3 MousePosition;

    //移動位置
    private Vector3 MovePosition;

    //敵リスト
    [SerializeField]
    private EnemyManeger Enemy_maneger;

    /// <summary>
    /// 浮遊モーションスクリプト
    /// </summary>
    Enemy_Fluffy _Fluffy;

    private void Start()
    {
        StartPosition = transform.position;
        _Fluffy = GetComponent<Enemy_Fluffy>();
    }

    void Update()
    {
        //初期位置からクリック位置まで
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
        //クリック位置から初期位置まで
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
        //スクリーン座標をワールド座標に変換
        MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //クリック位置から一番近いオブジェクトをリストから検索
        Vector3 NearbyEnemy = Enemy_maneger.EnemyPointSearch(MousePosition);

        if (MousePosition == NearbyEnemy) 
        {
            flg = false;
        }
        else
        {
            //クリック位置から一番近いオブジェクトに移動
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


