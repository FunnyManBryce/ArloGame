using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour
{
    public int Stage;
    public int Wave;
    static public int enemiesAlive;
    int enemiesToSpawn;
    public int[] enemiesPerWave;
    public GameObject[] enemies;
    public GameObject[] spawnPoints;
    public GameObject boss;
    public GameObject victoryPage;
    bool waveStarted = false;
    bool bossAlive;
    float spawnTimer;
    void Start()
    {
        enemiesAlive = 0; //code might screw me over later we'll see
        enemiesToSpawn = enemiesPerWave[Wave];
        waveStarted = true;
        spawnTimer = Random.Range(1, 2);
    }

    void Update()
    {
        if (enemiesToSpawn > 0 && spawnTimer <= 0)
        {
            Instantiate(enemies[Random.Range(0,enemies.Length)], spawnPoints[Random.Range(0, 4)].transform.position, Quaternion.identity);
            enemiesToSpawn--;
            enemiesAlive++;
            spawnTimer = Random.Range(1, 3);
        }
        else if (waveStarted == true)
        {
            spawnTimer -= Time.deltaTime;
        }
        if(waveStarted == true && enemiesAlive == 0 && enemiesToSpawn == 0)
        {
            Wave++;
            enemiesToSpawn = enemiesPerWave[Wave];
            waveStarted = true;
            spawnTimer = Random.Range(1, 2);
            if(Wave == 4)
            {
                Instantiate(boss, spawnPoints[Random.Range(0, 4)].transform.position, Quaternion.identity);
                enemiesAlive++;
            }
            if(Wave == 5)
            {
                //go to victory scene
                victoryPage.SetActive(true);
            }
           
        }
    }

    /*void WaveStart()
    {
        
    }*/

}
