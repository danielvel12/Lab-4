using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject enemyPrefab; 
    private float spawnRange = 9; 
    public int enemyCount; 
    public int waveNumber = 1; 
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber); 
    }

    // Update is called once per frame
    private Vector3 GenerateSpawnPostion()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ); 
        return randomPos;  
    }

    void Update()
    {
        enemyCount = FindObjectOftype<EnemyContrtoller>().Length; 
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber); 
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPostion(), enemyPrefab.transform.Rotation); 
        }
    }
}
