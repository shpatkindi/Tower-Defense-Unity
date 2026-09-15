using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public GameObject enemyPrefab;

    public GameObject CreateEnemy(EnemyData data, Vector3 spawnPosition)
    {
        GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Enemy enemyScript = newEnemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.data = data;
        }

        return newEnemy;
    }
}