using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private float minSpawnRadius = 4, maxSpawnRadius = 20;
    [SerializeField] private float minTimeSpawn = 0.1f, maxTimeSpawn = 2;

    [SerializeField] private GameObject[] enemy;

   

    private void Start()
    {
        StartCoroutine(SpawnAnEnemy());
    }
    IEnumerator SpawnAnEnemy()
    {
        float timeSpawn = Random.Range(minTimeSpawn, maxTimeSpawn);
        float spawnRadius = Random.Range(minSpawnRadius, maxSpawnRadius);
        Vector2 spawnPos = GameObject.Find("Player").transform.position;
        spawnPos += Random.insideUnitCircle.normalized * spawnRadius;

        Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(timeSpawn);
        StartCoroutine(SpawnAnEnemy());
    }
}
