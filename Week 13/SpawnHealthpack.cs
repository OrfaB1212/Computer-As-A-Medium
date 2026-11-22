using UnityEngine;
using System.Collections;
public class SpawnHealthpack : MonoBehaviour
{
    public GameObject HealthpackPrefab;
    public float spawnRangeX;
    public float spawnRangeY;
    public bool isSpawning = true;
    // Start is called once before the first execution of Update after the
    
void Start()
    {
        StartCoroutine(SpawnHealthpackNow());
    }
    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator SpawnHealthpackNow()
    {
        while (isSpawning == true)
        {
            Spawn();
            yield return new WaitForSeconds(3f);
        }
    }
    void Spawn()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPosition = transform.position + new Vector3(randomX, randomY,
        0f);
        Destroy(Instantiate(HealthpackPrefab, spawnPosition, Quaternion.identity), 5f);
    }
}