using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public EnemyFactory factory;
    public EnemyData[] enemyTypes; // Slot-et për 3 ScriptableObjects
    public float spawnInterval = 2f;

    void Start()
    {
        StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (WaypointPath.points != null && WaypointPath.points.Length > 0 && enemyTypes.Length > 0)
            {
                // Zgjidh një nga 3 ScriptableObjects rastësisht
                EnemyData randomData = enemyTypes[Random.Range(0, enemyTypes.Length)];
                Vector3 startPos = WaypointPath.points[0].position;

                factory.CreateEnemy(randomData, startPos);
            }
        }
    }
}