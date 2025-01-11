using UnityEngine;

public class TurretSelection : MonoBehaviour
{
    public GameObject selectedTurret; // Referencia a la torreta seleccionada
    public LayerMask turretLayer; // Capa para identificar las torretas en el raycast

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo del ratón
        {
            SelectTurret();
        }
    }

    void SelectTurret()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, turretLayer))
        {
            GameObject turret = hit.collider.gameObject;

            if (turret.GetComponent<TurretBase>() != null)
            {
                selectedTurret = turret;
                Debug.Log($"Selected turret: {turret.name}");
            }
        }
    }
}

