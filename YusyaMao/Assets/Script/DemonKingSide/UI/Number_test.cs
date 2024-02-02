using UnityEngine;
using UnityEngine.Rendering;

public class Number_test : MonoBehaviour
{
    //�\���ʒu
    Vector3 position;

    //�\���֘A
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
            //�����i�[
            this.point = point;

            CreateNum(point,number);

            GetComponent<SortingGroup>().sortingOrder = dam_sort;

            dam_sort++;
            if (dam_sort > SORT_MAX)
            {
                dam_sort = 0;
            }
       
    }

    //�`��p�̐��������
    private void CreateNum(int point,int number)
    {
        //������o��
        int digit = ChkDigit(point);

        //����Prefab��ǂݍ���
        GameObject obj = LoadObject(number);

        //Debug.LogError(obj.name);

        parent = new GameObject("parent");

        parent.transform.parent = transform;

        parent.transform.position = Vector3.zero;
        parent.transform.localPosition = Vector3.zero;

        //���������I�u�W�F�N�g������ēo�^
        for (int i = 0; i < digit; i++)
        {
            GameObject numObj = Instantiate(obj) as GameObject;

            //�q���Ƃ��ēo�^
            numObj.transform.parent = parent.transform;
            numObj.transform.position = Vector3.zero;
            numObj.transform.localPosition = Vector3.zero;

            //���݃`�F�b�N���Ă��錅�̐���������o��
            int digNum = GetPointDigit(point, i + 1);

            //�|�C���g���琔����؂�ւ���
            numObj.GetComponent<NumCtrl>().ChangeSprite(digNum);

            //�T�C�Y��Get����
            float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

            //�ʒu�����炷
            float ajs_x = size_w * i - (size_w * digit) / 2;
            Vector3 pos=new Vector3(numObj.transform.position.x - ajs_x, numObj.transform.position.y, numObj.transform.position.z);
            numObj.transform.position = pos;

            numObj = null;
        
        }
    }

    public static int ChkDigit(int num)
    {
        //�O�̏ꍇ�ꌅ�Ƃ��ĕԂ�
        if (num == 0)
        {
            return 1;
        }

        //�ΐ��ŕԂ�
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

    // �w�肵���b����ɃI�u�W�F�N�g��j�󂷂�R���[�`��
    public void DestroyObject(float seconds)
    {
        for(int i = transform.childCount-1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject, seconds);
        }

        
    }
}
