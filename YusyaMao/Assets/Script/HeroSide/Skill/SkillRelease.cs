using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRelease : MonoBehaviour
{
    public GameObject[] skillObjects; // �q�I�u�W�F�N�g���i�[����z��

    void Start()
    {
        // �q�I�u�W�F�N�g���擾���Ĕz��Ɋi�[
        skillObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            skillObjects[i] = transform.GetChild(i).gameObject;
        }

    }
}
