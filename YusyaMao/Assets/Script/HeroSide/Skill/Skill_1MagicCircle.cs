using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class MagicCircle : MonoBehaviour
{
    [Header("回転スピード")]
    public float RotateSpeed;

    private void Update()
    {
        //魔法陣回転
        transform.Rotate(0f, 0f, RotateSpeed * Time.deltaTime);

    }

}
