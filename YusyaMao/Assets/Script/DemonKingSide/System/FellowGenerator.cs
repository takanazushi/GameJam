using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FellowGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] FellowsPrefabs;

    [SerializeField]
    private GameObject fellowParent;

    [SerializeField]
    private PlayerDoragonData playerData;

    private int maxCount = 10;
    private float minGenerateInterval = 1.0f;
    private float maxGenerateInterval = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateFellow());
    }

    IEnumerator GenerateFellow()
    {
        while (true)
        {
            if (fellowParent.transform.childCount >= maxCount)
            {
                yield return null;
                continue;
            }

            Vector3 position = new Vector3(15, Random.Range(-4, 2), 0);
            float generateInterval=Random.Range(minGenerateInterval, maxGenerateInterval);
            yield return new WaitForSeconds(generateInterval);

            int prefabIndex = Random.Range(0, FellowsPrefabs.Length);

            if (prefabIndex == 0)
            {
                if (playerData.CanUseSKill)
                {
                    continue;
                }
            }

            if (prefabIndex == 1)
            {
                if (playerData.AttackRange >= 11)
                {
                    continue;
                }
            }

            GameObject fellow = Instantiate(FellowsPrefabs[prefabIndex], position, Quaternion.identity);
            fellow.transform.parent = fellowParent.transform;
        }
    }
}
