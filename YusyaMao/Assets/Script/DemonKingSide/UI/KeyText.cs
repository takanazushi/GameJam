using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KeyText : MonoBehaviour
{
    //表示位置
    Vector3 position;

    //表示関連
    private int point;
    private float size;

    private int dam_sort = 21;
    private int SORT_MAX = 30000;

    private bool display;

    private GameObject parent;

    public void TextInit(int point)
    {
        //情報を格納
        this.point = point;

        CreateNum(point);

        GetComponent<SortingGroup>().sortingOrder = dam_sort;

        dam_sort++;
        if (dam_sort > SORT_MAX)
        {
            dam_sort = 0;
        }

    }

    //描画用の数字を作る
    private void CreateNum(int point)
    {

        //数字Prefabを読み込む
        GameObject obj = LoadTextObject();

        parent = new GameObject("parent");

        parent.transform.parent = transform;

        parent.transform.position = Vector3.zero;
        parent.transform.localPosition = Vector3.zero;

        GameObject numObj = Instantiate(obj) as GameObject;

        //子供として登録
        numObj.transform.parent = parent.transform;
        numObj.transform.position = Vector3.zero;
        numObj.transform.localPosition = Vector3.zero;

        //ポイントから数字を切り替える
        numObj.GetComponent<KeyCtrl>().ChangeSprite(point);

        //サイズをGetする
        float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

        Vector3 pos = new Vector3(numObj.transform.position.x, numObj.transform.position.y, numObj.transform.position.z);
        numObj.transform.position = pos;
    }

    public static int ChkDigit(int num)
    {
        //０の場合一桁として返す
        if (num == 0)
        {
            return 1;
        }

        //対数で返す
        return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);
    }

    public static int GetPointDigit(int num, int digit)
    {
        int res = 0;
        int pow_dig = (int)Mathf.Pow(10, digit);

        if (digit == 1)
        {
            res = num - (num / pow_dig) * pow_dig;
        }
        else
        {
            res = (num - (num / pow_dig) * pow_dig) / (int)Mathf.Pow(10, (digit - 1));
        }

        return res;
    }

    public static GameObject LoadTextObject()
    {
        GameObject obj;

        obj = (GameObject)Resources.Load("pref_Text");

        return obj;
    }

    // 指定した秒数後にオブジェクトを破壊するコルーチン
    public void DestroyTextObject(float seconds)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject, seconds);
        }


    }
}
