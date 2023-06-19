using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] m_spawnPoints;
    public List<GameObject> m_enemiesToSpawn;
    private int m_waveCount; 
    public int m_wave;
    private int m_enemyType;
    private bool m_spawning;
    private int m_enemiesSpawned;
    private GameManager m_gameManager;
 
    // Start is called before the first frame update
    void Start()
    {
        m_waveCount = 2;
        m_wave = 1;
        m_spawning = false;
        m_enemiesSpawned = 0;
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_spawning == false && m_enemiesSpawned == m_gameManager.m_defeatedEnemies)
        {
            StartCoroutine(ISpawnWave(m_waveCount));
        }
        if (m_wave == 6)
        {
            StopAllCoroutines();
        }
        
    }

    IEnumerator ISpawnWave(int p_waveCount)
    {
        m_spawning = true;
        yield return new WaitForSeconds(4);
        for (int i = 0; i < p_waveCount; i++)
        {
            SpawningEnemy(m_wave);
            yield return new WaitForSeconds(2);
        }
        m_wave += 1;
        m_waveCount += 2;
        m_spawning = false;

        yield break;
    }


    void SpawningEnemy(int p_wave)
    {
        int l_spawnPos = Random.Range(0, 4);
        if (p_wave == 1)
        {
           m_enemyType = 1;
        }
        else if (p_wave < 4)
        {
            m_enemyType = Random.Range(0, 2);
        }
        else
        {
            m_enemyType = Random.Range(0, 3);
        }

        Instantiate(m_enemiesToSpawn[m_enemyType], m_spawnPoints[l_spawnPos].transform.position, m_spawnPoints[l_spawnPos].transform.rotation);
        m_enemiesSpawned+=1;
    }




 

}
