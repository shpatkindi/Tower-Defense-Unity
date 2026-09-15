using UnityEngine;

[CreateAssetMenu(fileName = "NewTowerData", menuName = "Tower Defense/Tower Data")]
public class TowerData : ScriptableObject
{
    public string towerName;
    public int cost = 100;
    public float range = 8f;
    public float fireRate = 1f; // Plumba për sekondë
    public GameObject bulletPrefab;
    public Color towerColor = Color.blue;
}