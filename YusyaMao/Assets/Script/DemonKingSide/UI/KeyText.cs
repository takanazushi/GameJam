using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class KeyText : MonoBehaviour
{
    //�\���ʒu
    Vector3 position;

    //�\���֘A
    private int point;
    private float size;

    private int dam_sort = 21;
    private int SORT_MAX = 30000;

    private bool display;

    private GameObject parent;

    public void TextInit(int point)
    {
        //�����i�[
        this.point = point;

        CreateNum(point);

        GetComponent<SortingGroup>().sortingOrder = dam_sort;

        dam_sort++;
        if (dam_sort > SORT_MAX)
        {
            dam_sort = 0;
        }

    }

    //�`��p�̐��������
    private void CreateNum(int point)
    {

        //����Prefab��ǂݍ���
        GameObject obj = LoadTextObject();

        parent = new GameObject("parent");

        parent.transform.parent = transform;

        parent.transform.position = Vector3.zero;
        parent.transform.localPosition = Vector3.zero;

        GameObject numObj = Instantiate(obj) as GameObject;

        //�q���Ƃ��ēo�^
        numObj.transform.parent = parent.transform;
        numObj.transform.position = Vector3.zero;
        numObj.transform.localPosition = Vector3.zero;

        //�|�C���g���琔����؂�ւ���
        numObj.GetComponent<KeyCtrl>().ChangeSprite(point);

        //�T�C�Y��Get����
        float size_w = numObj.GetComponent<SpriteRenderer>().bounds.size.x;

        Vector3 pos = new Vector3(numObj.transform.position.x, numObj.transform.position.y, numObj.transform.position.z);
        numObj.transform.position = pos;
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

    // �w�肵���b����ɃI�u�W�F�N�g��j�󂷂�R���[�`��
    public void DestroyTextObject(float seconds)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject, seconds);
        }


    }
}
