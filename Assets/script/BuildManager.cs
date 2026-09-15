using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance;

    public TowerData kulla1;
    public TowerData kulla2;
    public TowerData kulla3;

    private TowerData towerToBuild;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void SelectKulla1() { towerToBuild = kulla1; }
    public void SelectKulla2() { towerToBuild = kulla2; }
    public void SelectKulla3() { towerToBuild = kulla3; }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && towerToBuild != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    BuildTowerOn(hit.point);
                }
            }
        }
    }

    void BuildTowerOn(Vector3 position)
    {
        GameObject towerGO = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        towerGO.transform.position = position + Vector3.up * 1f;

        Tower towerScript = towerGO.AddComponent<Tower>();
        towerScript.data = towerToBuild;

        towerToBuild = null; // Fshin selektimin pasi ndërtohet kulla
    }
}