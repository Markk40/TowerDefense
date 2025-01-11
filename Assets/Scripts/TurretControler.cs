using UnityEngine;

public class TurretController : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab de la torreta
    private bool placementMode = false; // Controla si estamos colocando torretas
    private const float yCoord = 3.902035f;
    private const int turretCost = 50; // Costo en puntos para colocar una torreta

    public void ActivatePlacementMode()
    {
        placementMode = true;
        Debug.Log("Turret placement mode activated.");
    }

    void Update()
    {
        if (placementMode && Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            PlaceTurret();
        }
    }

    void PlaceTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 adjustedPosition = new Vector3(hit.point.x, yCoord, hit.point.z);

            if (hit.collider.CompareTag("Path"))
            {
                Debug.Log("You cannot place a turret on the path.");
                return;
            }

            BoxCollider turretCollider = turretPrefab.GetComponent<BoxCollider>();
            if (turretCollider == null)
            {
                Debug.LogError("The turret prefab does not have a BoxCollider.");
                return;
            }

            Vector3 colliderSize = new Vector3(
                turretCollider.size.x * turretPrefab.transform.localScale.x,
                turretCollider.size.y * turretPrefab.transform.localScale.y,
                turretCollider.size.z * turretPrefab.transform.localScale.z
            );
            Vector3 halfExtents = colliderSize / 2f;

            Collider[] collidersInTurret = Physics.OverlapBox(adjustedPosition, halfExtents, Quaternion.identity, LayerMask.GetMask("Turret"));
            if (collidersInTurret.Length > 0)
            {
                Debug.Log("You cannot place a turret here, another turret is already present.");
                return;
            }

            if (ScoreManager.Instance.SpendPoints(turretCost))
            {
                Instantiate(turretPrefab, adjustedPosition, Quaternion.identity);
                Debug.Log("Turret placed at: " + adjustedPosition);
            }
            else
            {
                Debug.Log("Not enough points to place a turret.");
            }

            placementMode = false;
        }
        else
        {
            Debug.Log("Click on a valid area of the map.");
        }
    }
}