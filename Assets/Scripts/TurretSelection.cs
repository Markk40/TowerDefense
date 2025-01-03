using UnityEngine;

public class SeleccionTorreta : MonoBehaviour
{
    public GameObject torretaSeleccionada; // Referencia a la torreta seleccionada
    public LayerMask capaTorreta; // Capa para identificar las torretas en el raycast

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Botón izquierdo del ratón
        {
            SeleccionarTorreta();
        }
    }

    void SeleccionarTorreta()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Comprobar si el raycast colisiona con una torreta
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, capaTorreta))
        {
            GameObject torreta = hit.collider.gameObject;

            // Verificar si el objeto tiene un script derivado de TorretaBase
            if (torreta.GetComponent<TorretaBase>() != null)
            {
                torretaSeleccionada = torreta; // Guardar la referencia
                Debug.Log($"Torreta seleccionada: {torreta.name}");
            }
        }
    }
}
