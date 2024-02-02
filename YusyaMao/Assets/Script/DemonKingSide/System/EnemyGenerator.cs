using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField, Header("“GPrefab‚Ì”z—ñ")]
    private GameObject[] enemyPrefabs;

    [SerializeField, Header("¶¬‚·‚é“G‚ÌÅ‘å”")]
    private int maxCount = 20;

    [SerializeField, Header("¶¬ˆÊ’u")]
    private GameObject enemyParent;

    private float minGenerateInterval = 1.0f;
    private float maxGenerateInterval = 3.0f;

    private bool isPaused = false;
    private Coroutine geterateEnemy;

    private void Start()
    {
        geterateEnemy = StartCoroutine(GenerateEnemy());
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

            if (!GameManager.Instance.IsGetTime_flg)
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
