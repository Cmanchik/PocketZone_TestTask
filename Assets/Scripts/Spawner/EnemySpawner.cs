using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<Transform> m_spawnPoints;

    [SerializeField]
    private GameObject m_enemy;

    [SerializeField]
    private int m_spawnCount;

    private void Start()
    {
        for (int i = 0; i < m_spawnCount; i++)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        Transform point = m_spawnPoints[Random.Range(0, m_spawnCount)];
        m_spawnPoints.Remove(point);

        Instantiate(m_enemy, point.position, Quaternion.identity);
    }
}
