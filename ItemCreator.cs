using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreator : MonoBehaviour    //재료 랜덤생성 스크립트
{
    public GameObject[] items;

    float timeMax = 2.5f;
    float timeMin = 1f;
    float timeSpawn;

    private float lastSpawnTime;

    void Start()
    {
        timeSpawn = Random.Range(timeMin, timeMax);
        lastSpawnTime = 0;
    }

    void Update()
    {
        if (Time.time >= lastSpawnTime + timeSpawn)
        {
            lastSpawnTime = Time.time;
            timeSpawn = Random.Range(timeMin, timeMax);
            Spawn();
        }
    }
    private void Spawn()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-4, 5), 0.275f, Random.Range(-4, 5));
        GameObject itemToCreate = items[Random.Range(0, items.Length)];
        GameObject item = Instantiate(itemToCreate, spawnPosition, Quaternion.identity);

        StartCoroutine(DestroyAfter(item, 10f));
    }
    IEnumerator DestroyAfter(GameObject target, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(target);
    }
}
