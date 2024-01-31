using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Header("敵Prefabの配列")]
    private GameObject[] enemyPrefabs;

    [SerializeField, Header("生成する敵の最大数")]
    private int maxCount = 20;

    [SerializeField, Header("生成位置")]
    private GameObject enemyParent;

    private float minGenerateInterval = 1.0f;
    private float maxGenerateInterval = 3.0f;

    private void Start()
    {
        StartCoroutine(GenerateEnemy());
    }

    IEnumerator GenerateEnemy()
    {
        while (true)
        {
            if (enemyParent.transform.childCount >= maxCount)
            {
                yield return null;
                continue;
            }

            Vector3 position = new Vector3(15, Random.Range(-3.25f, 1.7f), 0.0f);
            float generateIntaval = Random.Range(minGenerateInterval, maxGenerateInterval);
            yield return new WaitForSeconds(generateIntaval);

            int prefabIndex = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyObj = Instantiate(enemyPrefabs[prefabIndex], position, Quaternion.identity);
            enemyObj.transform.parent = enemyParent.transform;
        }
    }
}
