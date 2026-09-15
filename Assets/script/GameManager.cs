using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Kjo e bën klasën Singleton
    public static GameManager Instance;

    public int playerHealth = 20;
    public int coins = 100;

    private void Awake()
    {
        // Kontrollon nëse ekziston vetëm një GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Nuk fshihet kur ndërrohet skena
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("Game Manager u aktivizua. Shëndeti: " + playerHealth);
    }
}