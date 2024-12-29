using UnityEngine;

public class ControladorTorretas : MonoBehaviour
{
    public GameObject prefabTorreta; // Prefab de la torreta
    private bool modoColocar = false; // Controla si estamos colocando torretas
    private const float yCoord = 3.902035f;
    private const int costoTorreta = 50; // Costo en puntos para colocar una torreta

    public void ActivarModoColocar()
    {
        modoColocar = true;
        Debug.Log("Modo colocar torreta activado.");
    }

    void Update()
    {
        if (modoColocar && Input.GetMouseButtonDown(0)) // Detecta clic izquierdo
        {
            ColocarTorreta();
        }
    }

    void ColocarTorreta()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("Path"))
            {
                // No permite colocar torretas en el path
                Debug.Log("No puedes colocar una torreta sobre el camino.");
                return; // No salir del modo colocar aún
            }
            else if (hit.collider.CompareTag("Map"))
            {
                // Verificar si hay suficientes puntos antes de colocar la torreta
                if (ScoreManager.Instance.SpendPoints(costoTorreta))
                {
                    Instantiate(prefabTorreta, hit.point, Quaternion.identity);
                    Debug.Log("Torreta colocada en: " + hit.point);

                    // Salir del modo colocar tras colocar la torreta correctamente
                    modoColocar = false;
                }
                else
                {
                    Debug.Log("No tienes suficientes puntos para colocar una torreta.");
                }
            }
        }
        else
        {
            Debug.Log("Haz clic en un área válida del mapa.");
        }
    }
}

