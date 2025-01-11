using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject turretLevel2Prefab; // Prefab de torreta de nivel 2
    public int upgradeCost = 50; // Costo en puntos para mejorar
    private TurretSelection turretSelection; // Referencia al script de selección de torreta

    void Start()
    {
        turretSelection = FindObjectOfType<TurretSelection>();
    }

    public void TryUpgradeTurret()
    {
        if (turretSelection.selectedTurret != null)
        {
            GameObject turret = turretSelection.selectedTurret;
            TurretBase turretBase = turret.GetComponent<TurretBase>();

            if (turretBase != null && turretBase.TurretLevel == 1)
            {
                if (ScoreManager.Instance.SpendPoints(upgradeCost))
                {
                    UpgradeTurret(turret);
                }
                else
                {
                    Debug.Log("Not enough points to upgrade the turret.");
                }
            }
            else
            {
                Debug.Log("The selected turret cannot be upgraded.");
            }
        }
        else
        {
            Debug.Log("No turret selected.");
        }
    }

    private void UpgradeTurret(GameObject turretLevel1)
    {
        Vector3 position = turretLevel1.transform.position;
        Quaternion rotation = turretLevel1.transform.rotation;

        GameObject newTurret = Instantiate(turretLevel2Prefab, position, rotation);

        Destroy(turretLevel1);

        Debug.Log("Turret upgraded!");
    }
}
