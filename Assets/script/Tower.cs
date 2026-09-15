using UnityEngine;

public class Tower : MonoBehaviour
{
    public TowerData data;
    private float fireCountdown = 0f;
    private Transform target;

    void Start()
    {
        if (data != null && GetComponent<Renderer>() != null)
        {
            GetComponent<Renderer>().material.color = data.towerColor;
        }
    }

    void Update()
    {
        UpdateTarget();

        if (target == null) return;

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / ((data != null) ? data.fireRate : 1f);
        }

        fireCountdown -= Time.deltaTime;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        float range = (data != null) ? data.range : 8f;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void Shoot()
    {
        if (data == null || data.bulletPrefab == null) return;
        GameObject bulletGO = Instantiate(data.bulletPrefab, transform.position + Vector3.up, Quaternion.identity);
        Bullet bullet = bulletGO.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
}