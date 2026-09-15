using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Tower Defense/Enemy Data")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public float speed = 3f;
    public int maxHealth = 10;
    public Color enemyColor = Color.red;
}