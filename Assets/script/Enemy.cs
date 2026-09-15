using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData data; // ScriptableObject i armikut

    private int waveIndex = 0;
    private Transform targetPoint;

    void Start()
    {
        // Vendos ngjyrën e armikut sipas ScriptableObject
        if (data != null)
        {
            GetComponent<Renderer>().material.color = data.enemyColor;
        }

        // Merr pikën e parë të rrugës
        if (WaypointPath.points != null && WaypointPath.points.Length > 0)
        {
            targetPoint = WaypointPath.points[0];
        }
    }

    void Update()
    {
        if (targetPoint == null) return;

        // Lëviz drejt pikës aktuale
        Vector3 dir = targetPoint.position - transform.position;
        float speed = (data != null) ? data.speed : 3f;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Kur arrin afër pikës, kalon te pika tjetër
        if (Vector3.Distance(transform.position, targetPoint.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (waveIndex >= WaypointPath.points.Length - 1)
        {
            Destroy(gameObject); // Arriti në fund të rrugës, fshihet
            return;
        }

        waveIndex++;
        targetPoint = WaypointPath.points[waveIndex];
    }
}