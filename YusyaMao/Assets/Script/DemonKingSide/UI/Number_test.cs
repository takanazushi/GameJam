using UnityEngine;
using UnityEngine.Rendering;

public class Number_test : MonoBehaviour
{
    //表示位置
    Vector3 position;

    //表示関連
    private int point;
    private float size;

    private int dam_sort = 5;
    private int SORT_MAX = 30000;

    private bool display;

    private GameObject parent;

    private void Start()
    {
        //Init(125, new Vector3(0, 0, 0));

    }

    public void Init(int point,int number)
    {
            //情報を格納
            this.point = point;

            CreateNum(point,number);

            GetComponent<SortingGroup>().sortingOrder = dam_sort;

            dam_sort++;
            if (dam_sort > SORT_MAX)
            {
                dam_sort = 0;
            }
       
    }

    //描画用の数字を作る
    private void CreateNum(int point,int number)
    {
        //桁割り出し
        int digit = ChkDigit(point);

        //数字Prefabを読み込む
        GameObject obj = LoadObject(number);

        //Debug.LogError(obj.name);

        parent = new GameObject("parent");

        parent.transform.parent = transform;

        parent.transform.position = Vector3.zero;
        parent.transform.localPosition = Vector3.zero;

        //桁分だけオブジェクトを作って登録
        for (int i = 0; i < digit; i++)
        {
            GameObject numObj = Instantiate(obj) as GameObject;

            //子供として登録
            numObj.transform.parent = parent.transform;
            numObj.transform.position = Vector3.zero;
            numObj.transform.localPosition = Vector3.zero;

            //現在チェックしている桁の数字を割り出す
            int digNum = GetPointDigit(point, i + 1);

            //ポイントから数字を切り替える
            numObj.GetComponent<NumCtrl>().ChangeSprite(digNum);

            //サイズをGetする
            float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

            //位置をずらす
            float ajs_x = size_w * i - (size_w * digit) / 2;
            Vector3 pos=new Vector3(numObj.transform.position.x - ajs_x, numObj.transform.position.y, numObj.transform.position.z);
            numObj.transform.position = pos;

            numObj = null;
        
        }
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

    public static int GetPointDigit(int num,int digit)
    {
        int res = 0;
        int pow_dig=(int)Mathf.Pow(10, digit);

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

    public static GameObject LoadObject(int index)
    {
        GameObject[] objs=Resources.LoadAll<GameObject>("Number");

        //Debug.Log(objs.Length);
        //Debug.LogError(objs[0].name);
        //Debug.LogError(objs[1].name);

        GameObject obj = objs[index];

        return obj;
    }

    // 指定した秒数後にオブジェクトを破壊するコルーチン
    public void DestroyObject(float seconds)
    {
        for(int i = transform.childCount-1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject, seconds);
        }

        
    }
}
