using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public Transform player;
    public float spawnTime;
    
    void Start()
    {
        SpawnNewEnemy();
    }

    void SpawnNewEnemy() {

        int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length-1));

        GameObject enemy = Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].transform.position, Quaternion.identity);
        enemy.GetComponent<Enemy>().target = player;
        Invoke("SpawnNewEnemy", spawnTime);
    }
}