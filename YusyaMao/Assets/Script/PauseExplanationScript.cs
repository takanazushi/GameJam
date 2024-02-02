using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseExplanationScript : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    [Header("�����e�L�X�g�{�b�N�X")]
    public TextMeshProUGUI TextField;

    [SerializeField, Space, Header("�\������")]
    private string Text;

    public void OnMouseEnter()
    {
        TextField.text = Text;
        Debug.Log(Text);
    }



    public void OnMouseExit()
    {
        TextField.text = "������ ���߂� �� �Ђ傤�� ����܂�";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TextField.text = Text;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TextField.text = "���߂�";
    }
}
