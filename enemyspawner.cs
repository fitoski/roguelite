using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float spawnDelay = 2f;
    public float spawnRangeX = 7f;
    public float spawnRangeZ = 15f;
    public GameObject player;
    public float minX = -5f;
    public float maxX = 5f;
    public float distanceFromPlayer = 5f;
    public float yOffset = 1.0f;
    public float minZ;
    public float maxZ;
    public Terrain terrain;
    public float groundHeight;

    void Start()
    {
        minZ = player.transform.position.z - distanceFromPlayer;
        maxZ = player.transform.position.z + distanceFromPlayer;
        groundHeight = terrain.SampleHeight(transform.position);
        yOffset = groundHeight + yOffset;
        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        spawnRangeX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
    }





    private Vector3 RandomSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = transform.position.y;
        float spawnPosZ = transform.position.z + spawnRangeZ;

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        return spawnPosition;
    }


    private void SpawnEnemy()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosY = yOffset;
        float randomZ = player.transform.position.z + Random.Range(spawnRangeZ * 0.5f, spawnRangeZ);

        Vector3 spawnPosition = new Vector3(randomX, spawnPosY, randomZ);

        if (Vector3.Distance(spawnPosition, player.transform.position) > distanceFromPlayer)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
        else
        {
            SpawnEnemy(); 
        }
    }
}
