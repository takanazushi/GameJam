using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField, Header("�v���C���[�̃f�[�^")]
    private PlayerDoragonData playerData;

    [SerializeField,Header("�v���C���[�X�L��")]
    private PlayerSkill skill;

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.CanUseSKill)
        {
            image.color = Color.red;
        }
        else
        {
            image.color = Color.black;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("������");
        skill.UseSkill();
    }
}
