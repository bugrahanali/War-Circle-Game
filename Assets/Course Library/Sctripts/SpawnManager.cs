using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 9;
    private int enemyCount;
    public int waveNumber=1;
    public GameObject powerupPrefab;
    public GameObject fail;
    public GameObject Player;



    // Start is called before the first frame update
    void Start()
    {

        SpawnEnmyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
       
    }
    private void SpawnEnmyWave(int enemycaount)
    {
        for (int i = 0; i < enemycaount; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount==0 && Player.transform.position.y > -4)
        {
            waveNumber++;
            SpawnEnmyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
        else if (Player.transform.position.y < -4)
        {
            Instantiate(fail, new Vector3(0.880577564f, 2, 1.47463298f), fail.transform.rotation);
        }

    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(spawnPositionX, 0, spawnPositionZ);

        return spawnPosition;
    }


}
