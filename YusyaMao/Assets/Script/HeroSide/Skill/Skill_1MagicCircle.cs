using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MagicCircle : MonoBehaviour
{
    [Header("��]�X�s�[�h")]
    public float RotateSpeed;

    private void Update()
    {
        //���@�w��]
        transform.Rotate(0f, 0f, RotateSpeed * Time.deltaTime);

    }

}
