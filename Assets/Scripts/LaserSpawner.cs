using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject[] laserPrefabs;
    public float spawnInterval = 2f;
    public float positionYRange = 4f;
    // 4.947146e-07

    void Start()
    {
        StartCoroutine(SpawnLasersRoutine());
    }

    private IEnumerator SpawnLasersRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            int randomIndex = Random.Range(0, laserPrefabs.Length);
            GameObject randomLaserPrefab = laserPrefabs[randomIndex];

            float randomY = Random.Range(-positionYRange, positionYRange);
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomY, transform.position.z);
            
            Instantiate(randomLaserPrefab, spawnPosition, transform.rotation);
        }
    }
}
